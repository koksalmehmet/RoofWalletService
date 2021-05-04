using System;
using MediatR;

namespace RoofWallet.Messages.Commands
{
    public class DeleteWallet : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}