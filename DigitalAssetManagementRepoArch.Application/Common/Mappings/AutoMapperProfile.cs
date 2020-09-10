using AutoMapper;
using DigitalAssetManagementRepoArch.Application.Ads;
using DigitalAssetManagementRepoArch.Application.Channels;
using DigitalAssetManagementRepoArch.Application.Countries;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using DigitalAssetManagementRepoArch.Application.PSChannelCountries;
using DigitalAssetManagementRepoArch.Application.PSChannelCountryAds;
using DigitalAssetManagementRepoArch.Application.PSChannels;
using DigitalAssetManagementRepoArch.Application.Strategies.Dtos;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ad, AdDto>();
            CreateMap<Channel, ChannelDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Phase, PhaseDto>();
            CreateMap<PSChannelCountry, PSChannelCountryDto>();
            CreateMap<PSChannelCountryAd, PSChannelCountryAdDto>();
            CreateMap<PSChannel, PSChannelDto>();
            CreateMap<Strategy, StrategyDto>();
            CreateMap<PhaseStrategy, PhaseStrategyDto>();
        }
    }
}