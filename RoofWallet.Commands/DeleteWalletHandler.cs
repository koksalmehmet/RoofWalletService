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
    public class DeleteWalletHandler : IRequestHandler<DeleteWallet, bool>
    {
        private readonly RoofWalletContext _context;

        public DeleteWalletHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteWallet request, CancellationToken cancellationToken)
        {
            Wallet wallet = await _context.Wallets
                .Include(x => x.Moneys)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            // İçinde para olan cüzdan silinemez.
            var isThereMoney = wallet.Moneys.Sum(x => x.Amount);
            if(isThereMoney > 0)
            {
                throw new Exception("İçinde para olan bir cüzdanı silemezsiniz!");
            }

            _context.Wallets.Remove(wallet);
            var delete = await _context.SaveChangesAsync(cancellationToken);
            return delete > 0;
        }
    }
}