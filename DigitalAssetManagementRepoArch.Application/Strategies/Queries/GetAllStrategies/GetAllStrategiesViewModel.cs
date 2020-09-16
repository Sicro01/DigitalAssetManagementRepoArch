using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies
{
    public class GetAllStrategiesViewModel
    {
        public IList<StrategyDto> AllStrategyDtoList { get; set; }
    }
}