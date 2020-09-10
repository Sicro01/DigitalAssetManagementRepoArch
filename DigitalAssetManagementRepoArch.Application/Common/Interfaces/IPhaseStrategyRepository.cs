using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IPhaseStrategyRepository
    {
        public Task<GetAllPhaseStrategiesViewModel> GetAllPhaseStrategyRepoQuery();
    }
}
