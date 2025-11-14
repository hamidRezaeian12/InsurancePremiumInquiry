using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;

namespace InsurancePremiumInquiry.Domain.Repositories
{
    public interface IBenefitRequestRepository
    {
        Task<List<BenefitRequest>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(BenefitRequest benefitRequest,CancellationToken cancellationToken=default);
        Task SaveChangeAsync(CancellationToken cancellationToken=default);
    }
}
