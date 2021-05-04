using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using Xunit;

namespace RoofWalletTests.Domain
{
    public class WalletEntityTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly RoofWalletContext _context;
        public WalletEntityTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _context = databaseFixture.ServiceProvider.GetService<RoofWalletContext>();
        }

        [Fact]
        public async Task Create_Wallet()
        {
            Wallet wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Name = "My Wallet 1",
                CreatedDate = DateTime.Now,
                OwnerId = Guid.NewGuid().ToString(),
                Moneys = new List<Money>
                {
                    new Money
                    {
                        Amount = 120.00M,
                        CurrencyCode = "TRY",
                        CreatedDate = DateTime.Now
                    },
                    new Money
                    {
                        Amount = 50.00M,
                        CurrencyCode = "USD",
                        CreatedDate = DateTime.Now
                    }
                }
            };
            await _context.Wallets.AddAsync(wallet);
            var result = await _context.SaveChangesAsync();
            
            Assert.True(result > 0);
        }
        
        [Fact]
        public async Task Update_Wallet()
        {
            // 
            await Create_Wallet();
            Wallet wallet = _context.Wallets.First();
            wallet.Name = "Wallet Rename";
            wallet.UpdatedDate = DateTime.Now;
            _context.Wallets.Update(wallet);
            var result = await _context.SaveChangesAsync();
            Assert.True(result > 0);
        }
        
        /// <summary>
        /// Burada beklenilen
        /// Bir cuzdan silindiginde o cuzdanin icindeki paralarda silinmesi.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Delete_Wallet()
        {
            await Create_Wallet();
            Wallet wallet = _context.Wallets.First();
            _context.Wallets.Remove(wallet);
            var result = await _context.SaveChangesAsync();
            Assert.True(result > 0);
        }
    }
}