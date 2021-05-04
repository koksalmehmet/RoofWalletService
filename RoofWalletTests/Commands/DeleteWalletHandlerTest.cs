using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoofWallet.Commands;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Commands;
using RoofWalletTests.Domain;
using Xunit;

namespace RoofWalletTests.Commands
{
    public class DeleteWalletHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        private readonly Guid _id = Guid.NewGuid();
        public DeleteWalletHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
            CreateWallet(_id);
        }

        [Fact]
        public async Task Delete_Wallet_Handler()
        {
            var request = new DeleteWallet()
            {
                Id = _id
            };
            var handler = new DeleteWalletHandler(_context);
            var exception = await Assert.ThrowsAsync<Exception>(() => 
                handler.Handle(request, CancellationToken.None));
            Assert.Equal("İçinde para olan bir cüzdanı silemezsiniz!", exception.Message);
        }
        
        private void CreateWallet(Guid id)
        {
            Wallet wallet = new Wallet
            {
                Id = id,
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
                        Amount = 1000.00M,
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
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
        }
    }
}