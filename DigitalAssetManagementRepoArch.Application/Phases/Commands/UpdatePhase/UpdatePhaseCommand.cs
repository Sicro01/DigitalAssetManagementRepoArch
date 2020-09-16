using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.UpdatePhase
{
    public class UpdatePhaseCommand : IRequest
    {
        public GetPhaseByIdViewModel UpdatePhaseViewModel;

        public UpdatePhaseCommand()
        {
        }

        public class UpdatePhaseCommandHandler : IRequestHandler<UpdatePhaseCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IPhaseRepository _phaseRepository;
            public UpdatePhaseCommandHandler(IApplicationDbContext context, IPhaseRepository phaseRepository)
            {
                _context = context;
                _phaseRepository = phaseRepository;
            }

            public async Task<Unit> Handle(UpdatePhaseCommand request, CancellationToken cancellationToken)
            {
                var originalEntity = await _context.Phases.FindAsync(request.UpdatePhaseViewModel.DisplayPhaseDto.Id);

                originalEntity.Name = request.UpdatePhaseViewModel.DisplayPhaseDto.Name;
                originalEntity.StartDate = request.UpdatePhaseViewModel.DisplayPhaseDto.StartDate;
                originalEntity.EndDate = request.UpdatePhaseViewModel.DisplayPhaseDto.EndDate;

                await _phaseRepository.UpdatePhaseRepo(originalEntity, cancellationToken);

                return Unit.Value;
            }
        }

    }
}