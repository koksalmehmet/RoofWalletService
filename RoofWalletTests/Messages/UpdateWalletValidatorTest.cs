using System;
using RoofWallet.Messages.Commands;
using Xunit;

namespace RoofWalletTests.Messages
{
    public class UpdateWalletValidatorTest
    {
        [Fact]
        public void Wallet_Should_Be_Invalid_When_Name_Empty()
        {
            var createWallet = new UpdateWallet
            {
                Id = Guid.NewGuid()
            };
            var updateWalletValidator = new UpdateWalletValidator();
            var validator = updateWalletValidator.Validate(createWallet);
            
            Assert.False(validator.IsValid);
            Assert.Contains(validator.Errors, x => x.ErrorMessage == "'Name' boş olmamalı.");
        }
        
        [Fact]
        public void Wallet_Should_Be_Valid_When_Update_Wallet()
        {
            
            var createWallet = new UpdateWallet
            {
                Id = Guid.NewGuid(),
                Name = "Wallet Name"
            };
            var updateWalletValidator = new UpdateWalletValidator();
            var validator = updateWalletValidator.Validate(createWallet);
            Assert.True(validator.IsValid);
        }
    }
}