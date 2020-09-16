using System.Reflection;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalAssetManagementRepoArch.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbContext Instance
        {
            get
            {
                var applicationDbContext = this;
                return applicationDbContext;
            }
        }

        public DbSet<Phase> Phases { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<PhaseStrategy> PhaseStrategies { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PSChannel> PSChannels { get; set; }
        public DbSet<PSChannelCountry> PSChannelCountries { get; set; }
        public DbSet<PSChannelCountryAd> PSChannelCountryAds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}