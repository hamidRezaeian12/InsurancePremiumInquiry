using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace InsurancePremiumInquiry.Application.Database
{
    public interface IInsurancePremiumInquiryContext
    {
        DbSet<BenefitRequest> BenefitRequests { get; set; }
        DbSet<Benefit> Benefits { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
