using InsurancePremiumInquiry.Application.Dto.BenefitRequests;

namespace InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Queries.GetAllBenefitRequest
{
    public class GetAllBenefitRequestQueryResponse
    {
        public List<BenefitRequestOutputDto> BenefitRequests { get; set; } = [];
    }
}
