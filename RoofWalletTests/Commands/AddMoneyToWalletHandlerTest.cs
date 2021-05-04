using System;
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
    public class AddMoneyToWalletHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        private readonly Guid _id = Guid.NewGuid();

        public AddMoneyToWalletHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
            CreateWallet(_id);
        }

        [Fact]
        public async Task Add_Money_To_Wallet_Handler()
        {
            var request = new AddMoneyToWallet()
            {
                Amount = 1200,
                CurrencyCode = "EUR",
                WalletId = _id
            };
            var handler = new AddMoneyToWalletHandler(_context);
            var response = await handler.Handle(request, CancellationToken.None);
            Assert.True(response);
        }

        private void CreateWallet(Guid id)
        {
            Wallet wallet = new Wallet
            {
                Id = id,
                Name = "My Wallet 1",
                CreatedDate = DateTime.Now,
                OwnerId = Guid.NewGuid().ToString(),
               
            };
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
        }
    }
}