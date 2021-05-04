using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoofWallet.Domain.Entities;

namespace RoofWallet.Domain.Configurations
{
    public class ProcessLogConfigurations : IEntityTypeConfiguration<ProcessLog>
    {
        public void Configure(EntityTypeBuilder<ProcessLog> builder)
        {
            builder.ToTable("ProcessLogs").HasKey(x => x.Id);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.CurrencyCode).IsRequired();
        }
    }
}