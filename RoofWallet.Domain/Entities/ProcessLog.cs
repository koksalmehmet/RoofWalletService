namespace RoofWallet.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessLog : BaseEntity
    {
        public ProcessLogType LogType { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public enum ProcessLogType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}