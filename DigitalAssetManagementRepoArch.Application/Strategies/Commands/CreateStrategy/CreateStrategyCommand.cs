using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Domain.Entities;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.CreateStrategy
{
    public class CreateStrategyCommand : IRequest
    {
        public CreateStrategyViewModel CreateStrategyViewModel;
        public CreateStrategyCommand()
        {
        }

        public class CreateStrategyCommandHandler : IRequestHandler<CreateStrategyCommand>
        {
            private readonly IStrategyRepository _strategyRepository;

            public CreateStrategyCommandHandler(IStrategyRepository strategyRepository)
            {
                _strategyRepository = strategyRepository;
            }

            public async Task<Unit> Handle(CreateStrategyCommand request, CancellationToken cancellationToken)
            {
                var createStrategy = new Strategy
                {
                    Name = request.CreateStrategyViewModel.CreateStrategyDto.Name,
                    StartDate= request.CreateStrategyViewModel.CreateStrategyDto.StartDate,
                    EndDate= request.CreateStrategyViewModel.CreateStrategyDto.EndDate
                };
                
                await _strategyRepository.CreateStrategyRepo(createStrategy, cancellationToken);
                return Unit.Value;
            }
        }
    }
}