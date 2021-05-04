using FluentValidation;

namespace RoofWallet.Messages.Commands
{
    public class UpdateWalletValidator : AbstractValidator<UpdateWallet>
    {
        public UpdateWalletValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}