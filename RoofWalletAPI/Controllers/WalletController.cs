using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoofWallet.Messages.Commands;
using RoofWallet.Messages.Models;
using RoofWallet.Messages.Queries;

namespace RoofWalletAPI.Controllers
{
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateWallet request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("AddMoneyToWallet")]
        public async Task<bool> Post([FromBody] AddMoneyToWallet request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] UpdateWallet request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromRoute] DeleteWallet request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpGet("GetWalletsByOwnerId/{ownerId}")]
        public async Task<WalletModel[]> Get([FromRoute]GetWalletsByOwnerId request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpGet("GetWalletById/{id}")]
        public async Task<WalletModel> Get([FromRoute]GetWalletById request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}