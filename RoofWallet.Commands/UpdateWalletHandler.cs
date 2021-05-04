using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Commands;

namespace RoofWallet.Commands
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWallet, bool>
    {
        private readonly RoofWalletContext _context;
        public UpdateWalletHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWallet request, CancellationToken cancellationToken)
        {
            Wallet wallet = await _context.Wallets.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            // Cüzdan yoksa hata gönder.
            if (wallet == null)
            {
                throw new Exception("Cüzdan bulunamadı!");
            }
            wallet.Name = request.Name;
            wallet.UpdatedDate = DateTime.Now;
            
            _context.Wallets.Update(wallet);
            var update = await _context.SaveChangesAsync(cancellationToken);
            return update > 0;
        }
    }
}