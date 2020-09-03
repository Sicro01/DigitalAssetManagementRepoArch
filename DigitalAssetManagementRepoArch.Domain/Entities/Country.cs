using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class Country 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IList<PSChannelCountry> PSChannelCountries { get; private set; } = new List<PSChannelCountry>();
    }
}
