using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder
                .Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
