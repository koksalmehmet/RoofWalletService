using System;
using MediatR;
using RoofWallet.Messages.Models;

namespace RoofWallet.Messages.Queries
{
    public class GetWalletById : IRequest<WalletModel>
    {
        public Guid Id { get; set; }
    }
}