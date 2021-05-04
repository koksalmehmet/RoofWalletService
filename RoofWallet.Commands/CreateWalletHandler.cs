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
    public class CreateWalletHandler : IRequestHandler<CreateWallet, Guid>
    {
        private readonly RoofWalletContext _context;
        public CreateWalletHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateWallet request, CancellationToken cancellationToken)
        {
            // Aynı owner'a ait aynı isimde cüzdan olmasının önüne geçer.
            var existsWalletName = await _context.Wallets.AnyAsync(
                x => x.OwnerId == request.OwnerId && string.Equals(x.Name, request.Name, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
            if (existsWalletName)
            {
                throw new Exception("Bu isimde daha önce bir cüzdan eklenmiş! Lütfen başka bir isim kullanınız!");
            }

            Wallet wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedDate = DateTime.Now,
                OwnerId = request.OwnerId,
            };
            
            // Cüzdan oluşturulurken para varsa eklenecek.
            if (request.Moneys != null && request.Moneys.Any())
            {
                wallet.Moneys = request.Moneys.Select(w => new Money
                {
                    Amount = w.Amount,
                    CurrencyCode = w.CurrencyCode,
                    CreatedDate = DateTime.Now,
                }).ToList();

                // Eklenen paraların logları tutuluyor.
                ProcessLog[] processLogs = wallet.Moneys.Select(x => new ProcessLog
                {
                    Amount = x.Amount,
                    CurrencyCode = x.CurrencyCode,
                    CreatedDate = DateTime.Now,
                    LogType = ProcessLogType.Deposit
                }).ToArray();
                await _context.ProcessLogs.AddRangeAsync(processLogs, cancellationToken);
            }

            await _context.Wallets.AddAsync(wallet, cancellationToken);
            var save = await _context.SaveChangesAsync(cancellationToken);
            return wallet.Id;
        }
    }
}