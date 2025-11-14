namespace InsurancePremiumInquiry.Application.Dto.BenefitRequests
{
    public class BenefitRequestOutputDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public List<BenefitOutputDto> Benefits { get; set; } = [];
    }
}
