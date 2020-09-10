using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;

namespace DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies
{
    public class GetAllPhaseStrategiesViewModel
    {
        public IList<PhaseDto> PhaseDtoList { get; set; }
        public IList<StrategyDto> StrategyDtoList { get; set; }
        public IList<PhaseStrategyDto> PhaseStrategyDtoList { get; set; }
    }
}
