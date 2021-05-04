using System;
using RoofWallet.Domain.Entities;

namespace RoofWallet.Messages.Models
{
    public class ProcessLogModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ProcessLogType LogType { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}