using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy
{
    public class GetStrategyByIdQuery : IRequest<GetStrategyByIdViewModel>
    {
        public int Id;

        public GetStrategyByIdQuery()
        {
        }

        public class GetStrategyByIdQueryHandler : IRequestHandler<GetStrategyByIdQuery, GetStrategyByIdViewModel>
        {
            private readonly IStrategyRepository _strategyRepository;

            public GetStrategyByIdQueryHandler(IStrategyRepository strategyRepository)
            {
                _strategyRepository = strategyRepository;
            }

            public async Task<GetStrategyByIdViewModel> Handle(GetStrategyByIdQuery request,
                CancellationToken cancellationToken)
            {
                return await _strategyRepository.GetStrategyByIdRepoQuery(request.Id);
            }
        }
    }
}
