using InsurancePremiumInquiry.Application.Database;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using InsurancePremiumInquiry.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InsurancePremiumInquiry.Infrastructure.Repositories
{
    public class BenefitRequestRepository : IBenefitRequestRepository
    {
        private readonly IInsurancePremiumInquiryContext _context;
        public BenefitRequestRepository(IInsurancePremiumInquiryContext context)
        {
            _context = context;
        }
        public Task<List<BenefitRequest>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.BenefitRequests.Include(c => c.Benefits).AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task AddAsync(BenefitRequest benefitRequest, CancellationToken cancellationToken = default)
        {
            await _context.BenefitRequests.AddAsync(benefitRequest, cancellationToken);
        }
        public Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
