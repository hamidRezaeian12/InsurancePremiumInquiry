using InsurancePremiumInquiry.Application.Database;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects;
using InsurancePremiumInquiry.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InsurancePremiumInquiry.Infrastructure.Database
{
    public class InsurancePremiumInquiryContext : DbContext, IInsurancePremiumInquiryContext
    {
        public InsurancePremiumInquiryContext(DbContextOptions<InsurancePremiumInquiryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BenefitRequestEntityConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BenefitRequest> BenefitRequests { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
    }
}
