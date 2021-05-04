using System;

namespace RoofWallet.Domain.Entities
{
    public class Money : BaseEntity
    {
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public Wallet Wallet { get; set; }
        public Guid WalletId { get; set; }
    }
}