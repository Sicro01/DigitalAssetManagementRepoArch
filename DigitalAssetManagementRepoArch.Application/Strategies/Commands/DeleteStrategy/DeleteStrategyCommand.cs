using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.DeleteStrategy
{
    public class DeleteStrategyCommand : IRequest
    {
        public int DeleteStrategyId;

        public DeleteStrategyCommand()
        {
        }

        public class DeleteStrategyCommandHandler : IRequestHandler<DeleteStrategyCommand>
        {
            private readonly IApplicationDbContext  _context;
            public DeleteStrategyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteStrategyCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Strategies.FindAsync(request.DeleteStrategyId);
                _context.Strategies.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}