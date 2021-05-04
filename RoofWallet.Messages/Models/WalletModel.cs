using System;

namespace RoofWallet.Messages.Models
{
    public class WalletModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        public string OwnerId { get; set; }
        public string Name { get; set; }
        
        public MoneyModel[] Moneys { get; set; }
    }
}