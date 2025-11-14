using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsurancePremiumInquiry.Infrastructure.Database.Configurations
{
    public class BenefitRequestEntityConfiguration : IEntityTypeConfiguration<BenefitRequest>
    {
        public void Configure(EntityTypeBuilder<BenefitRequest> builder)
        {
            builder.ToTable("BenefitRequests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasMany(x => x.Benefits)
                   .WithOne(b => b.BenefitRequest) 
                   .HasForeignKey(b => b.BenefitRequestId) 
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                   .FindNavigation(nameof(BenefitRequest.Benefits))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
