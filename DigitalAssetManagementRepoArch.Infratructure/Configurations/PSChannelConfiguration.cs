using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class PSChannelConfiguration : IEntityTypeConfiguration<PSChannel>
    {
        public void Configure(EntityTypeBuilder<PSChannel> builder)
        {
            builder
                .HasOne(p => p.PhaseStrategy)
                .WithMany(p => p.PSChannelList)
                .HasForeignKey(p => p.PhaseStrategyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Channel)
                .WithMany(p => p.PSChannels)
                .HasForeignKey(p => p.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
