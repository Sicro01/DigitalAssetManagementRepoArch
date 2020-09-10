using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.PSChannelCountries;

namespace DigitalAssetManagementRepoArch.Application.Countries
{
    public class CountryDto 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IList<PSChannelCountryDto> PSChannelCountryDtoList { get; private set; } = new List<PSChannelCountryDto>();
    }
}
