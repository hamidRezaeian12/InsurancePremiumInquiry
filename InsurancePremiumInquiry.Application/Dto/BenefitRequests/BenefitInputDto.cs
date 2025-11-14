using InsurancePremiumInquiry.Domain.Enums;

namespace InsurancePremiumInquiry.Application.Dto.BenefitRequests
{
    public class BenefitInputDto
    {
        public BenefitType BenefitType { get; set; }
        public decimal Amount { get; set; }
    }
}
