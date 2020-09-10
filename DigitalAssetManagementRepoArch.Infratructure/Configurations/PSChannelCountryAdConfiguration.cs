using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class PSChannelCountryAdConfiguration : IEntityTypeConfiguration<PSChannelCountryAd>
    {
        public void Configure(EntityTypeBuilder<PSChannelCountryAd> builder)
        {
            builder
                .HasOne(p => p.Ad)
                .WithMany(p => p.PSChannelCountryAds)
                .HasForeignKey(p => p.AdId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.PSChannelCountry)
                .WithMany(p => p.PSChannelCountryAdList)
                .HasForeignKey(p => p.PSChannelCountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
