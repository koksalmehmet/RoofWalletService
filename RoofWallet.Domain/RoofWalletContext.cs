using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoofWallet.Domain.Configurations;
using RoofWallet.Domain.Entities;

namespace RoofWallet.Domain
{
    public class RoofWalletContext : DbContext
    {
        public RoofWalletContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Money> Moneys { get; set; }
        public DbSet<ProcessLog> ProcessLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WalletConfigurations());
            modelBuilder.ApplyConfiguration(new MoneyConfigurations());
            modelBuilder.ApplyConfiguration(new ProcessLogConfigurations());
            base.OnModelCreating(modelBuilder);
            
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}