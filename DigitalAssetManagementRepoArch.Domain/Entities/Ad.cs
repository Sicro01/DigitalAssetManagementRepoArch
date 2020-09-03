using System.Collections.Generic;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class Ad
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
        public IList<PSChannelCountryAd> PSChannelCountryAds { get; private set; } = new List<PSChannelCountryAd>();
    }
}
