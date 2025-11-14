namespace InsurancePremiumInquiry.Application.Dto.BenefitRequests
{
    public class BenefitRequestInputDto
    {
        public string Title { get; set; } = default!;
        public List<BenefitInputDto> Benefit { get; set; } = [];
    }
}
