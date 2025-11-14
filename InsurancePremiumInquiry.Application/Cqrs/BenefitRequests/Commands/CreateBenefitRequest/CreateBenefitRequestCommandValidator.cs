using FluentValidation;

namespace InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Commands.CreateBenefitRequest
{
    public class CreateBenefitRequestCommandValidator:AbstractValidator<CreateBenefitRequestCommand>
    {
        public CreateBenefitRequestCommandValidator()
        {
            
        }
    }
}
