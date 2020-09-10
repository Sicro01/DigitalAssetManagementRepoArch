using AutoMapper;
using AutoMapper.QueryableExtensions;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;

namespace DigitalAssetManagementRepoArch.Infrastructure.Persistence.Repositories
{
    public class PhaseStrategyRepository : IPhaseStrategyRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PhaseStrategyRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllPhaseStrategiesViewModel> GetAllPhaseStrategyRepoQuery()
        {
            return new GetAllPhaseStrategiesViewModel
            {
                PhaseDtoList = await _context.Phases.ProjectTo<PhaseDto>(_mapper.ConfigurationProvider).ToListAsync(),

                StrategyDtoList = await _context.Strategies.ProjectTo<StrategyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),

                PhaseStrategyDtoList = await _context.PhaseStrategies
                    .ProjectTo<PhaseStrategyDto>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}