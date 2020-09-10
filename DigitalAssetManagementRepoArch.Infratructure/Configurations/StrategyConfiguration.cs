using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class StrategyConfiguration : IEntityTypeConfiguration<Strategy>
    {
        public void Configure(EntityTypeBuilder<Strategy> builder)
        {
            builder
                .Property(s => s.Name)
                .HasColumnName("Name")
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(s => s.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(s => s.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
