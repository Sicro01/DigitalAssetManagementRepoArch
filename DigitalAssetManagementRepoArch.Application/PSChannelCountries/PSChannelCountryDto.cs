using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.Countries;
using DigitalAssetManagementRepoArch.Application.PSChannelCountryAds;
using DigitalAssetManagementRepoArch.Application.PSChannels;

namespace DigitalAssetManagementRepoArch.Application.PSChannelCountries
{
    public class PSChannelCountryDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int PSChannelId { get; set; }
        public virtual CountryDto Country { get; set; }
        public virtual PSChannelDto PSChannelDto { get; set; }
        public IList<PSChannelCountryAdDto> PSChannelCountryAdDtoList { get; private set; } = new List<PSChannelCountryAdDto>();
    }
}
