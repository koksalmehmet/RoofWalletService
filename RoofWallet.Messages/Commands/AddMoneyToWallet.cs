﻿using System;
using MediatR;

namespace RoofWallet.Messages.Commands
{
    public class AddMoneyToWallet : IRequest<Guid>
    {
        public Guid WalletId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}