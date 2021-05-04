using FluentValidation;

namespace RoofWallet.Messages.Commands
{
    public class AddMoneyToWalletValidator : AbstractValidator<AddMoneyToWallet>
    {
        public AddMoneyToWalletValidator()
        {
            RuleFor(x => x.CurrencyCode).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
        }
    }
}