using System;
using RoofWallet.Messages.Commands;
using RoofWallet.Messages.Models;
using Xunit;

namespace RoofWalletTests.Messages
{
    public class CreateWalletValidatorTest
    {
        [Fact]
        public void Wallet_Should_Be_Invalid_When_Name_And_OwnerId_Empty()
        {
            var createWallet = new CreateWallet
            {
                Moneys = new[]
                {
                    new MoneyModel
                    {
                        Amount = 120M,
                        CurrencyCode = "USD"
                    }
                }
            };
            var createWalletValidator = new CreateWalletValidator();
            var validator = createWalletValidator.Validate(createWallet);
            
            Assert.False(validator.IsValid);
            Assert.Contains(validator.Errors, x => x.ErrorMessage == "'Name' boş olmamalı.");
            Assert.Contains(validator.Errors, x => x.ErrorMessage == "'Owner Id' boş olmamalı.");
        }
        
        [Fact]
        public void Wallet_Should_Be_Valid_When_Create_Wallet()
        {
            var createWallet = new CreateWallet
            {
                OwnerId = Guid.NewGuid().ToString(),
                Name = "Wallet Name",
                Moneys = new[]
                {
                    new MoneyModel
                    {
                        Amount = 120M,
                        CurrencyCode = "USD"
                    }
                }
            };
            var createWalletValidator = new CreateWalletValidator();
            var validator = createWalletValidator.Validate(createWallet);
            
            Assert.True(validator.IsValid);
        }
    }
}