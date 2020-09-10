using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies
{
    public class GetAllPhaseStrategiesQuery : IRequest<GetAllPhaseStrategiesViewModel>
    {
        public GetAllPhaseStrategiesQuery()
        {
        }

        public class GetAllPhaseStrategiesQueryHandler : IRequestHandler<GetAllPhaseStrategiesQuery, GetAllPhaseStrategiesViewModel>
        {
            private readonly IPhaseStrategyRepository _phaseStrategyRepository;

            public GetAllPhaseStrategiesQueryHandler(IPhaseStrategyRepository phaseStrategyRepository)
            {
                _phaseStrategyRepository = phaseStrategyRepository;
            }

            public async Task<GetAllPhaseStrategiesViewModel> Handle(GetAllPhaseStrategiesQuery request,
                CancellationToken cancellationToken)
            {
                return await _phaseStrategyRepository.GetAllPhaseStrategyRepoQuery();
            }
        }
    }
}
