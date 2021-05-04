using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoofWallet.Domain;
using RoofWallet.Messages.Models;
using RoofWallet.Messages.Queries;

namespace RoofWallet.Queries
{
    public class GetWalletsByOwnerIdHandler : IRequestHandler<GetWalletsByOwnerId, WalletModel[]>
    {
        private readonly RoofWalletContext _context;

        public GetWalletsByOwnerIdHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<WalletModel[]> Handle(GetWalletsByOwnerId request, CancellationToken cancellationToken)
        {
            var wallets = await _context.Wallets
                .Include(x=> x.Moneys)
                .Where(x => x.OwnerId == request.OwnerId)
                .ToListAsync(cancellationToken);

            var response = new List<WalletModel>();
            foreach (var wallet in wallets)
            {
                WalletModel model = new WalletModel
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
                    model.Moneys = wallet.Moneys
                        .GroupBy(money => money.CurrencyCode, money => money, (key, items) => new MoneyModel
                        {
                            Amount = items.Sum(y => y.Amount),
                            CurrencyCode = key
                        }).ToArray();
                }

                response.Add(model);
            }

            return response.ToArray();
        }
    }
}