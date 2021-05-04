using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoofWallet.Domain.Entities;

namespace RoofWallet.Domain.Configurations
{
    public class MoneyConfigurations : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.ToTable("Moneys").HasKey(x => x.Id);
            builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Amount).IsRequired();
        }
    }
}