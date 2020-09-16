using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using DigitalAssetManagementRepoArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalAssetManagementRepoArch.Infrastructure.Persistence.Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StrategyRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllStrategiesViewModel> GetAllStrategiesRepoQuery()
        {
            return new GetAllStrategiesViewModel
            {
                AllStrategyDtoList = await _context.Strategies.ProjectTo<StrategyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync()
            };
        }
        public async Task<GetStrategyByIdViewModel> GetStrategyByIdRepoQuery(int id)
        {
            return new GetStrategyByIdViewModel
            {
                DisplayStrategyDto = await _context.Strategies.ProjectTo<StrategyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(s => s.Id == id)
            };
        }

        public async Task<Unit> UpdateStrategyRepo(Strategy updatedStrategy, CancellationToken cancellationToken)
        {
            _context.Strategies.Update(updatedStrategy);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> CreateStrategyRepo(Strategy newStrategy, CancellationToken cancellationToken)
        {
            await _context.Strategies.AddAsync(newStrategy, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}