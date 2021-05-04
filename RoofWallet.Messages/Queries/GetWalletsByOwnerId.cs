using MediatR;
using RoofWallet.Messages.Models;

namespace RoofWallet.Messages.Queries
{
    public class GetWalletsByOwnerId : IRequest<WalletModel[]>
    {
        public string OwnerId { get; set; }
    }
}