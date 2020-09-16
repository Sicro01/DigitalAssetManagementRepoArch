using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.DeletePhase
{
    public class DeletePhaseCommand : IRequest
    {
        public int DeletePhaseId;

        public DeletePhaseCommand()
        {
        }

        public class DeletePhaseCommandHandler : IRequestHandler<DeletePhaseCommand>
        {
            private readonly IPhaseRepository _phaseRepository;
            private readonly IApplicationDbContext _context;
            public DeletePhaseCommandHandler(IPhaseRepository phaseRepository, IApplicationDbContext context)
            {
                _phaseRepository = phaseRepository;
                _context = context;
            }

            public async Task<Unit> Handle(DeletePhaseCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Phases.FindAsync(request.DeletePhaseId);
                _context.Phases.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}