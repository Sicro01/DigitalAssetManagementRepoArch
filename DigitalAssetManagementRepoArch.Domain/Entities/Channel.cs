using System.Collections.Generic;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PSChannel> PSChannels { get; private set; } = new List<PSChannel>();
    }
}
