using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder
                .Property(a => a.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.AspectRatio)
                .HasColumnName("AspectRatio")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.CopyRequest)
                .HasColumnName("CopyRequest")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.Device)
                .HasColumnName("Device")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.Dimensions)
                .HasColumnName("Dimensions")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.FileSize)
                .HasColumnName("FileSize")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.FileTypes)
                .HasColumnName("FileTypes")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(a => a.VideoDuration)
                .HasColumnName("VideoDuration")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
