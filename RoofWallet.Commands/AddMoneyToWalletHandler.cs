using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Commands;

namespace RoofWallet.Commands
{
    public class AddMoneyToWalletHandler : IRequestHandler<AddMoneyToWallet, Guid>
    {
        private readonly RoofWalletContext _context;

        public AddMoneyToWalletHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddMoneyToWallet request, CancellationToken cancellationToken)
        {
            Money money = new Money
            {
                Amount = request.Amount,
                WalletId = request.WalletId,
                CreatedDate = DateTime.Now,
                CurrencyCode = request.CurrencyCode,
                Id = Guid.NewGuid()
            };
            ProcessLog processLog = new ProcessLog
            {
                Amount = request.Amount,
                CurrencyCode = request.CurrencyCode,
                CreatedDate = DateTime.Now,
                LogType = ProcessLogType.Deposit
            };
            await _context.Moneys.AddAsync(money, cancellationToken);
            await _context.ProcessLogs.AddAsync(processLog, cancellationToken);
            var create = await _context.SaveChangesAsync(cancellationToken);
            return money.Id;
        }
    }
}