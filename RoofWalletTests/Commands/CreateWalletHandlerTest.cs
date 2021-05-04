using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoofWallet.Commands;
using RoofWallet.Domain;
using RoofWallet.Messages.Commands;
using RoofWallet.Messages.Models;
using RoofWalletTests.Domain;
using Xunit;

namespace RoofWalletTests.Commands
{
    public class CreateWalletHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        public CreateWalletHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
        }

        [Fact]
        public async Task Create_Wallet_Handler()
        {
            var request = new CreateWallet
            {
                Name = "Name",
                Moneys = new[]
                {
                    new MoneyModel
                    {
                        Amount = 120M,
                        CurrencyCode = "USD"
                    }
                },
                OwnerId = Guid.NewGuid().ToString()
            };
            var handler = new CreateWalletHandler(_context);
            var response = await handler.Handle(request, CancellationToken.None);
            Assert.True(response);
        }
    }
}