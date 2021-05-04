using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoofWallet.Domain;

namespace RoofWalletTests.Domain
{
    public class DatabaseFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// DI
        /// </summary>
        public DatabaseFixture()
        {
            var services = new ServiceCollection();
            services.AddDbContext<RoofWalletContext>(option => option.UseInMemoryDatabase("RoofWallet"));
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider?.Dispose();
        }
    }
}