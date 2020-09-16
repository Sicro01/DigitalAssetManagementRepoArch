using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDbContext
    {
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<PhaseStrategy> PhaseStrategies { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PSChannel> PSChannels { get; set; }
        public DbSet<PSChannelCountry> PSChannelCountries { get; set; }
        public DbSet<PSChannelCountryAd> PSChannelCountryAds { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
