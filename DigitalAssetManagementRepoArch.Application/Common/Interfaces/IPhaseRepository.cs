using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using DigitalAssetManagementRepoArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IPhaseRepository
    {
        public Task<GetAllPhasesViewModel> GetAllPhasesRepoQuery();
        public Task<GetPhaseByIdViewModel> GetPhaseByIdRepoQuery(int id);
        public Task<Unit> UpdatePhaseRepo (Phase updatedPhase, CancellationToken cancellationToken);
        public Task<Unit> CreatePhaseRepo(Phase newPhase, CancellationToken cancellationToken);
        public Task<Unit> DeletePhaseRepo(Phase deletePhase, CancellationToken cancellationToken);
    }
}