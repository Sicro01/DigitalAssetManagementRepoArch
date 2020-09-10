using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.UpdateStrategy
{
    public class UpdateStrategyCommand : IRequest
    {
        public StrategyDto UpdatedStrategyDto;

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
                var originalEntity = await _context.Strategies.FindAsync(request.UpdatedStrategyDto.Id);

                originalEntity.Name = request.UpdatedStrategyDto.Name;
                originalEntity.StartDate= request.UpdatedStrategyDto.StartDate;
                originalEntity.EndDate= request.UpdatedStrategyDto.EndDate;

                await _strategyRepository.UpdateStrategy(originalEntity, cancellationToken);
                
                return Unit.Value;
            }
        }
    }
    
}
