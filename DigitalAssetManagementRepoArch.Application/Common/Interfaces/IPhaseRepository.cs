using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IPhaseRepository
    {
        public Task<GetAllPhasesViewModel> GetAllPhasesRepoQuery();
        public Task<GetPhaseByIdViewModel> GetPhaseByIdRepoQuery(int id);
        public Task<int> UpdatePhase (Phase updatedPhase, CancellationToken cancellationToken);
        public Task<int> CreatePhase(CreatePhaseViewModel createPhaseViewModel, CancellationToken cancellationToken);
    }
}