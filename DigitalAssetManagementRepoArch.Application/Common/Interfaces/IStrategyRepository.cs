using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IStrategyRepository
    {
        public Task<GetStrategyByIdViewModel> GetStrategyById(int id);
        public Task<int> UpdateStrategy(Strategy updatedStrategy, CancellationToken cancellationToken);
    }
}