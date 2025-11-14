using InsurancePremiumInquiry.Domain.Enums;

namespace InsurancePremiumInquiry.Application.Dto.BenefitRequests
{
    public class BenefitOutputDto
    {
        public Guid Id { get; set; }
        public BenefitType BenefitType { get; set; }
        public string Name { get; set; } = default!;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal Amount { get; set; }
    }
}
