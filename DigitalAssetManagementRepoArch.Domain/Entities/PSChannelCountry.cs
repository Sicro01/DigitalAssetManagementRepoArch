using System.Collections.Generic;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class PSChannelCountry 
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int PSChannelId { get; set; }
        public virtual Country Country { get; set; }
        public virtual PSChannel PSChannel { get; set; }
        public IList<PSChannelCountryAd> PSChannelCountryAds { get; private set; } = new List<PSChannelCountryAd>();
    }
}
