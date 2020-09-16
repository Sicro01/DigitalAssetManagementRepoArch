using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class PSChannelCountryConfiguration : IEntityTypeConfiguration<PSChannelCountry>
    {
        public void Configure(EntityTypeBuilder<PSChannelCountry> builder)
        {
            builder.HasOne(p => p.Country)
                .WithMany(p => p.PSChannelCountries)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.PSChannel)
                .WithMany(p => p.PSChannelCountryList)
                .HasForeignKey(p => p.PSChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
