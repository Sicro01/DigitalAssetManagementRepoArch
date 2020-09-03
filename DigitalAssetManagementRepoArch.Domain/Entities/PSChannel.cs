using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class PSChannel 
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int PhaseStrategyId { get; set; }
        public Channel Channel { get; set; }
        public PhaseStrategy PhaseStrategy { get; set; }
        public IList<PSChannelCountry> PSChannelCountries { get; private set; } = new List<PSChannelCountry>();
    }
}
