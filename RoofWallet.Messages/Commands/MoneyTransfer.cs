using System;
using MediatR;

namespace RoofWallet.Messages.Commands
{
    public class MoneyTransfer : IRequest<bool>
    {
        public Guid FromWalletId { get; set; }
        public Guid ToWalletId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}