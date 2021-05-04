using MediatR;
using RoofWallet.Messages.Models;

namespace RoofWallet.Messages.Commands
{
    public class CreateWallet : IRequest<bool>
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public MoneyModel[] Moneys { get; set; }
    }
}