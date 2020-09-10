using System.Collections.Generic;
using DigitalAssetManagementRepoArch.Application.PSChannels;

namespace DigitalAssetManagementRepoArch.Application.Channels
{
    public class ChannelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PSChannelDto> PSChannelDtoList { get; private set; } = new List<PSChannelDto>();
    }
}
