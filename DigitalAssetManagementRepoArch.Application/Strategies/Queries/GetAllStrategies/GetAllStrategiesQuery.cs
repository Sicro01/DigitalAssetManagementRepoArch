using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies
{
    public class GetAllStrategiesQuery : IRequest<GetAllStrategiesViewModel>
    {
        public GetAllStrategiesQuery()
        {
        }

        public class GetAllStrategiesQueryHandler : IRequestHandler<GetAllStrategiesQuery, GetAllStrategiesViewModel>
        {
            private readonly IStrategyRepository _strategyRepository;

            public GetAllStrategiesQueryHandler(IStrategyRepository strategyRepository)
            {
                _strategyRepository = strategyRepository;
            }

            public async Task<GetAllStrategiesViewModel> Handle(GetAllStrategiesQuery request,
                CancellationToken cancellationToken)
            {
                return await _strategyRepository.GetAllStrategiesRepoQuery();
            }
        }
    }
}