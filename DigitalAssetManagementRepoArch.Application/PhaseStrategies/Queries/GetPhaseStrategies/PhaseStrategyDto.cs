using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.PSChannels;
using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;

namespace DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies
{
    public class PhaseStrategyDto
    {
        public int Id { get; set; }
        public int PhaseId { get; set; }
        public int StrategyId { get; set; }
        public virtual PhaseDto Phase { get; set; }
        public virtual StrategyDto Strategy { get; set; }
        public IList<PSChannelDto> PsChannelDtoList { get; set; }
    }
}