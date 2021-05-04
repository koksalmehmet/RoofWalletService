using System.Collections.Generic;

namespace RoofWallet.Domain.Entities
{
    /// <summary>
    /// Gerçek hayattan esinlenerek,
    /// Her insan cüzdan taşır. Cüzdanında bir veya birden fazla para birimi olabilir.
    /// O yüzden eklenen bir cüzdana birden fazla para birimi ile para eklenebilir yapıyoruz.
    /// </summary>
    public class Wallet : BaseEntity
    {
        /// <summary>
        /// Burada data tipini özellikle string belirtiyorum.
        /// Ben bir cüzdan servisiyim. Cüzdan sahibi olmak isteyenin id'si Guid tipinde de olabileceği gibi Guid olmayan başka bir yapı da olabilir.
        /// Örneğin, WalletService'den faydalanmak isteyen external bir service verilerini unique olarak e-mail adresi ile tutmak isteyebilir.
        /// </summary>
        public string OwnerId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Wallet ile money arasında one to many ilişkisi olacak.
        /// </summary>
        public IEnumerable<Money> Moneys { get; set; }
    }
}