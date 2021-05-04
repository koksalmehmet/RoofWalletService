using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Commands;

namespace RoofWallet.Commands
{
    public class MoneyTransferHandler : IRequestHandler<MoneyTransfer, bool>
    {
        private readonly RoofWalletContext _context;
        private readonly IMediator _mediator;
        public MoneyTransferHandler(RoofWalletContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(MoneyTransfer request, CancellationToken cancellationToken)
        {
            var fromWallet =
                await _context.Wallets
                    .Include(x => x.Moneys)
                    .FirstOrDefaultAsync(x => x.Id == request.FromWalletId, cancellationToken);

            var moneys = fromWallet.Moneys.Where(x => x.CurrencyCode == request.CurrencyCode).ToList();
            var sumMoney = moneys.Sum(x=> x.Amount);
            if (request.Amount > sumMoney)
            {
                throw new Exception("Cüzdanınızda yeteli bakiye yok!");
            }
            
            var paymentMoney = request.Amount;
            foreach (var money in moneys)
            {
                if(paymentMoney == 0)
                    break;
                
                if (money.Amount <= paymentMoney)
                {
                    paymentMoney -= money.Amount;
                    _context.Moneys.Remove(money);
                    var processLog = new ProcessLog
                    {
                        Amount = money.Amount,
                        CurrencyCode = request.CurrencyCode,
                        CreatedDate = DateTime.Now,
                        LogType = ProcessLogType.Transfer
                    };
                    _context.ProcessLogs.Add(processLog);
                }
                else
                {
                    money.Amount -= paymentMoney;
                    paymentMoney = 0;
                    _context.Moneys.Update(money);
                    var processLog = new ProcessLog
                    {
                        Amount = paymentMoney,
                        CurrencyCode = request.CurrencyCode,
                        CreatedDate = DateTime.Now,
                        LogType = ProcessLogType.Transfer
                    };
                    _context.ProcessLogs.Add(processLog);
                }
            }

            AddMoneyToWallet addMoneyToWallet = new AddMoneyToWallet
            {
                Amount = request.Amount,
                CurrencyCode = request.CurrencyCode,
                WalletId = request.ToWalletId
            };
            var response = await _mediator.Send(addMoneyToWallet, cancellationToken);
            return Guid.TryParse(response.ToString(), out _);
        }
    }
}