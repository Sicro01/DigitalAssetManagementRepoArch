using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.PSChannelCountryAds;

namespace DigitalAssetManagementRepoArch.Application.Ads
{
    public class AdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Device { get; set; }
        public string Dimensions { get; set; }
        public string CopyRequest { get; set; }
        public string AspectRatio { get; set; }
        public string FileTypes { get; set; }
        public string FileSize { get; set; }
        public string VideoDuration { get; set; }
        public IList<PSChannelCountryAdDto> PSChannelCountryAdDtoList { get; private set; } = new List<PSChannelCountryAdDto>();
    }
}
