using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.Channels;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using DigitalAssetManagementRepoArch.Application.PSChannelCountries;

namespace DigitalAssetManagementRepoArch.Application.PSChannels
{
    public class PSChannelDto 
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int PhaseStrategyId { get; set; }
        public ChannelDto ChannelDto { get; set; }
        public PhaseStrategyDto PhaseStrategyDto { get; set; }
        public IList<PSChannelCountryDto> PSChannelCountryDtoList { get; private set; } = new List<PSChannelCountryDto>();
    }
}
