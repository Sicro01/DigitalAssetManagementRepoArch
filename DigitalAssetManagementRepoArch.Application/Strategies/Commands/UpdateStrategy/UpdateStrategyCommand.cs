using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.UpdateStrategy
{
    public class UpdateStrategyCommand : IRequest
    {
        public GetStrategyByIdViewModel UpdateStrategyViewModel;

        public UpdateStrategyCommand()
        {
        }

        public class UpdateStrategyCommandHandler : IRequestHandler<UpdateStrategyCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IStrategyRepository _strategyRepository;
            public UpdateStrategyCommandHandler(IApplicationDbContext context, IStrategyRepository strategyRepository)
            {
                _context = context;
                _strategyRepository = strategyRepository;
            }

            public async Task<Unit> Handle(UpdateStrategyCommand request, CancellationToken cancellationToken)
            {
                var originalEntity = await _context.Strategies.FindAsync(request.UpdateStrategyViewModel.DisplayStrategyDto.Id);

                originalEntity.Name = request.UpdateStrategyViewModel.DisplayStrategyDto.Name;
                originalEntity.StartDate= request.UpdateStrategyViewModel.DisplayStrategyDto.StartDate;
                originalEntity.EndDate= request.UpdateStrategyViewModel.DisplayStrategyDto.EndDate;

                await _strategyRepository.UpdateStrategyRepo(originalEntity, cancellationToken);
                
                return Unit.Value;
            }
        }
    }
    
}
