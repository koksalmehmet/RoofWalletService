using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Models;
using RoofWallet.Messages.Queries;

namespace RoofWallet.Queries
{
    public class GetWalletByIdHandler : IRequestHandler<GetWalletById, WalletModel>
    {
        private readonly RoofWalletContext _context;
        public GetWalletByIdHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<WalletModel> Handle(GetWalletById request, CancellationToken cancellationToken)
        {
            Wallet wallet = await _context.Wallets
                .Include(x=> x.Moneys)
                .FirstOrDefaultAsync(x => x.Id == request.Id
                , cancellationToken);
            // Cuzdan yoksa hata gonder
            if (wallet == null)
            {
                throw new Exception("Cuzdan bulunamadi!");
            }

            WalletModel response = new WalletModel
            {
                Id = wallet.Id,
                Name = wallet.Name,
                CreatedDate = wallet.CreatedDate,
                OwnerId = wallet.OwnerId,
                UpdatedDate = wallet.UpdatedDate
            };

            if (wallet.Moneys.Any())
            {
                // Cuzdandaki paralar kur bazli gruplaniyor.
                response.Moneys = wallet.Moneys
                    .GroupBy(money => money.CurrencyCode, money => money, (key, items) => new MoneyModel
                    {
                        Amount = items.Sum(y => y.Amount),
                        CurrencyCode = key
                    }).ToArray();
            }

            return response;
        }
    }
}