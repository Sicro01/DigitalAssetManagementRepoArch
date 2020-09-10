using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class PhaseConfiguration : IEntityTypeConfiguration<Phase>
    {
        public void Configure(EntityTypeBuilder<Phase> builder)
        {
            builder
                .Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(p => p.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
