using System;
using MediatR;

namespace RoofWallet.Messages.Commands
{
    public class UpdateWallet : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}