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
        public async Task<Guid> Post([FromBody] CreateWallet request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("AddMoneyToWallet")]
        public async Task<Guid> Post([FromBody] AddMoneyToWallet request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpPost("MoneyTransfer")]
        public async Task<bool> Post([FromBody] MoneyTransfer request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpPut("{id:guid}")]
        public async Task<Guid> Put(Guid id, [FromBody] UpdateWallet request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<bool> Delete(Guid id)
        {
            var request = new DeleteWallet
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return response;
        }
        
        [HttpGet("GetWalletsByOwnerId/{ownerId}")]
        public async Task<WalletModel[]> Get(string ownerId)
        {
            var request = new GetWalletsByOwnerId()
            {
                OwnerId = ownerId
            };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpGet("GetWalletById/{id:guid}")]
        public async Task<WalletModel> Get(Guid id)
        {
            var request = new GetWalletById
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpGet("Logs")]
        public async Task<ProcessLogModel[]> Get()
        {
            var request = new GetProcessLogs();
            var response = await _mediator.Send(request);
            return response;
        }
    }
}