using System;
using System.Collections.Generic;
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
    public class GetWalletsByOwnerIdHandlerTest : IClassFixture<DatabaseFixture>
    {
        private readonly RoofWalletContext _context;
        private const string _ownerId = "test@test.com";

        public GetWalletsByOwnerIdHandlerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.ServiceProvider.GetRequiredService<RoofWalletContext>();
            CreateWallets(_ownerId);
        }

        [Fact]
        public async Task Get_Wallets_By_Owner_Id()
        {
            var request = new GetWalletsByOwnerId
            {
                OwnerId = _ownerId
            };
            var handler = new GetWalletsByOwnerIdHandler(_context);
            var response = await handler.Handle(request, CancellationToken.None);
            
            Assert.Equal(3, response.Length);
        }
        
        private void CreateWallets(string ownerId)
        {
            List<Wallet> wallets = new List<Wallet>();
            for (int i = 0; i < 3; i++)
            {
                Wallet wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Name = $"My Wallet {i+1}",
                    CreatedDate = DateTime.Now,
                    OwnerId = ownerId,
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
                            Amount = 1000.00M,
                            CurrencyCode = "USD",
                            CreatedDate = DateTime.Now
                        },
                        new Money
                        {
                            Amount = 200.00M,
                            CurrencyCode = "USD",
                            CreatedDate = DateTime.Now
                        },
                        new Money
                        {
                            Amount = 700.00M,
                            CurrencyCode = "USD",
                            CreatedDate = DateTime.Now
                        },
                        new Money
                        {
                            Amount = 1500.00M,
                            CurrencyCode = "EUR",
                            CreatedDate = DateTime.Now
                        }
                    }
                };
                wallets.Add(wallet);
            }
            
            _context.Wallets.AddRange(wallets);
            _context.SaveChanges();
        }
    }
}