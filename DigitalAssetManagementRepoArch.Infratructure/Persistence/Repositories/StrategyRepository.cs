using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries;
using DigitalAssetManagementRepoArch.Domain.Entities;
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
        public async Task<GetStrategyByIdViewModel> GetStrategyById(int id)
        {
            return new GetStrategyByIdViewModel
            {
                DisplayStrategy = await _context.Strategies.ProjectTo<StrategyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(s => s.Id == id)
            };
        }

        public async Task<int> UpdateStrategy(Strategy updatedStrategy, CancellationToken cancellationToken)
        {
            _context.Strategies.Update(updatedStrategy);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedStrategy.Id;
        }
    }
}