using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using DigitalAssetManagementRepoArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IStrategyRepository
    {
        public Task<GetAllStrategiesViewModel> GetAllStrategiesRepoQuery();
        public Task<GetStrategyByIdViewModel> GetStrategyByIdRepoQuery(int id);
        public Task<Unit> UpdateStrategyRepo(Strategy updatedStrategy, CancellationToken cancellationToken);
        public Task<Unit> CreateStrategyRepo(Strategy newStrategy, CancellationToken cancellationToken);
    }
}