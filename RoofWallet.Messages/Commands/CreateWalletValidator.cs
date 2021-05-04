using FluentValidation;

namespace RoofWallet.Messages.Commands
{
    public class CreateWalletValidator : AbstractValidator<CreateWallet>
    {
        public CreateWalletValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}