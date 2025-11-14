using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsurancePremiumInquiry.Infrastructure.Database.Configurations
{
    public class BenefitEntityConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(b => b.BenefitType).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();

            builder.Property(b => b.MinAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.MaxAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.Amount).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(b => b.BenefitRequest)  
                   .WithMany(br => br.Benefits)
                   .HasForeignKey(b => b.BenefitRequestId) 
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
