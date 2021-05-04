using MediatR;
using RoofWallet.Messages.Models;

namespace RoofWallet.Messages.Queries
{
    public class GetProcessLogs : IRequest<ProcessLogModel[]>
    {
        
    }
}