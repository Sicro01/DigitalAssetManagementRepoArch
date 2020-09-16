using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases
{
    public class GetAllPhasesQuery : IRequest<GetAllPhasesViewModel>
    {
        public GetAllPhasesQuery()
        {
        }

        public class GetAllPhaseStrategiesQueryHandler : IRequestHandler<GetAllPhasesQuery, GetAllPhasesViewModel>
        {
            private readonly IPhaseRepository _phaseRepository;

            public GetAllPhaseStrategiesQueryHandler(IPhaseRepository phaseRepository)
            {
                _phaseRepository = phaseRepository;
            }
            public async Task<GetAllPhasesViewModel> Handle(GetAllPhasesQuery request, CancellationToken cancellationToken)
            {
                return await _phaseRepository.GetAllPhasesRepoQuery();
            }
        }
    }
}