using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class PSChannelCountryAd 
    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public int PSChannelCountryId { get; set; }
        public Ad Ad { get; set; }
        public PSChannelCountry PSChannelCountry { get; set; }
    }
}
