using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalAssetManagementRepoArch.Domain.Entities;

namespace DigitalAssetManagementRepoArch.Infrastructure.Configurations
{
    public class PhaseStrategyConfiguration : IEntityTypeConfiguration<PhaseStrategy>
    {
        public void Configure(EntityTypeBuilder<PhaseStrategy> builder)
        {
            builder
                .HasOne(ps => ps.Phase)
                .WithMany(p => p.PhaseStrategyList)
                .HasForeignKey(p => p.PhaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ps => ps.Strategy)
                .WithMany(s => s.PhaseStrategyList)
                .HasForeignKey(p => p.StrategyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
