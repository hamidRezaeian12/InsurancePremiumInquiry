using InsurancePremiumInquiry.Application.Base.Commands;
using InsurancePremiumInquiry.Application.Dto.BenefitRequests;

namespace InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Commands.CreateBenefitRequest
{
    public class CreateBenefitRequestCommand : CommandBase<CreateBenefitRequestCommandResponse>
    {
        public CreateBenefitRequestCommand(string title,
                                           List<BenefitInputDto> benefits)
        {
            Title = title;
            Benefits = benefits;
        }
        public string Title { get; private set; }
        public List<BenefitInputDto> Benefits { get; private set; }
    }

}
