using AutoMapper;
using AutoMapper.QueryableExtensions;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using DigitalAssetManagementRepoArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

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
                DisplayAllPhaseDtoList = await _context.Phases.ProjectTo<PhaseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync()
            };
        }

        public  async Task<GetPhaseByIdViewModel> GetPhaseByIdRepoQuery(int id)
        {
            return new GetPhaseByIdViewModel
            {
                DisplayPhaseDto = await _context.Phases.ProjectTo<PhaseDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == id)
            };
        }

        public async Task<Unit> UpdatePhaseRepo(Phase updatedPhase, CancellationToken cancellationToken)
        {
            _context.Phases.Update(updatedPhase);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> CreatePhaseRepo(Phase newPhase, CancellationToken cancellationToken)
        {
            await _context.Phases.AddAsync(newPhase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> DeletePhaseRepo(Phase deletePhase, CancellationToken cancellationToken)
        {
            var p =  await _context.Phases.FindAsync(deletePhase.Id);
            _context.Phases.Remove(p);
            //_context.Instance.Entry(deletePhase).State = EntityState.Deleted; 
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
