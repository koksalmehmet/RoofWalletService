using System;
using MediatR;

namespace RoofWallet.Messages.Commands
{
    public class UpdateWallet : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}