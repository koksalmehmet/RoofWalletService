using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoofWallet.Domain;
using RoofWallet.Domain.Entities;
using RoofWallet.Messages.Queries;
using RoofWallet.Queries;
using RoofWalletTests.Domain;
using Xunit;

namespace RoofWalletTests.Queries
{
    public class GetWalletByIdHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        private readonly Guid _id = Guid.NewGuid();
        public GetWalletByIdHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
            CreateWallet(_id);
        }
        [Fact]
        public async Task Get_Wallet_By_Id_Handler()
        {
            var request = new GetWalletById
            {
                Id = _id
            };
            var handler = new GetWalletByIdHandler(_context);
            var response = await handler.Handle(request, CancellationToken.None);
            Assert.Equal(2, response.Moneys.Length);
            Assert.Equal(1120, response.Moneys.First(y=> y.CurrencyCode == "TRY").Amount);
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