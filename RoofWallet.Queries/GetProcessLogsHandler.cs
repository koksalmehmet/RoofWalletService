using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoofWallet.Domain;
using RoofWallet.Messages.Models;
using RoofWallet.Messages.Queries;

namespace RoofWallet.Queries
{
    public class GetProcessLogsHandler : IRequestHandler<GetProcessLogs, ProcessLogModel[]>
    {
        private readonly RoofWalletContext _context;

        public GetProcessLogsHandler(RoofWalletContext context)
        {
            _context = context;
        }

        public Task<ProcessLogModel[]> Handle(GetProcessLogs request, CancellationToken cancellationToken)
        {
            var logs = _context.ProcessLogs.Select(x => new ProcessLogModel
            {
                Id = x.Id,
                Amount = x.Amount,
                CreatedDate = x.CreatedDate,
                CurrencyCode = x.CurrencyCode,
                LogType = x.LogType,
                UpdatedDate = x.UpdatedDate
            }).ToArrayAsync(cancellationToken);
            return logs;
        }
    }
}