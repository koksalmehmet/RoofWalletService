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
    public class UpdateWalletHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        private readonly Guid _id = Guid.NewGuid();

        public UpdateWalletHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
            CreateWallet(_id);
        }

        [Fact]
        public async Task Update_Wallet_Handler()
        {
            var request = new UpdateWallet
            {
                Id = _id,
                Name = "Wallet Name"
            };
            var handler = new UpdateWalletHandler(_context);
            var response = await handler.Handle(request, CancellationToken.None);
            Assert.True(Guid.TryParse(response.ToString(), out _));
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
    