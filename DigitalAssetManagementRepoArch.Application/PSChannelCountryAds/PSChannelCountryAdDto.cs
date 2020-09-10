using DigitalAssetManagementRepoArch.Application.Ads;
using DigitalAssetManagementRepoArch.Application.PSChannelCountries;

namespace DigitalAssetManagementRepoArch.Application.PSChannelCountryAds
{
    public class PSChannelCountryAdDto
    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public int PSChannelCountryId { get; set; }
        public AdDto AdDto { get; set; }
        public PSChannelCountryDto PSChannelCountryDto { get; set; }
    }
}
