using AutoMapper;
using AutoMapper.QueryableExtensions;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using DigitalAssetManagementRepoArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Infrastructure.Persistence.Repositories
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PhaseRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllPhasesViewModel> GetAllPhasesRepoQuery()
        {
            return new GetAllPhasesViewModel
            {
                AllPhaseDtoList = await _context.Phases.ProjectTo<PhaseDto>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
        public  async Task<GetPhaseByIdViewModel> GetPhaseByIdRepoQuery(int id)
        {
            return new GetPhaseByIdViewModel
            {
                DisplayPhase = await _context.Phases.ProjectTo<PhaseDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == id)
            };
        }

        public async Task<int> UpdatePhase(Phase updatedPhase, CancellationToken cancellationToken)
        {
            _context.Phases.Update(updatedPhase);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedPhase.Id;
        }

        public async Task<int> CreatePhase(CreatePhaseViewModel createPhaseViewModel, CancellationToken cancellationToken)
        {
            var phase = new Phase
            {
                Name = createPhaseViewModel.NewPhase.Name,
                StartDate = createPhaseViewModel.NewPhase.StartDate,
                EndDate = createPhaseViewModel.NewPhase.EndDate
            };

            await _context.Phases.AddAsync(phase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return phase.Id;
        }
    }
}
