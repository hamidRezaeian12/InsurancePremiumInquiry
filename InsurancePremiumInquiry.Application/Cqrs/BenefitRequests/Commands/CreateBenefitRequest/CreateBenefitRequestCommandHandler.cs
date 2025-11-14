using InsurancePremiumInquiry.Application.Base.Commands;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects;
using InsurancePremiumInquiry.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Commands.CreateBenefitRequest
{
    public class CreateBenefitRequestCommandHandler : CommandHandlerBase<CreateBenefitRequestCommand, CreateBenefitRequestCommandResponse>
    {
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        public CreateBenefitRequestCommandHandler(ILoggerFactory loggerFactory,
                                                  IBenefitRequestRepository benefitRequestRepository) : base(loggerFactory)
        {
            _benefitRequestRepository = benefitRequestRepository;
        }
        protected override async Task<CreateBenefitRequestCommandResponse> Batch(CreateBenefitRequestCommand command, CancellationToken cancellationToken = default)
        {
            var benefitRequest = BenefitRequest.Create(command.Title);
            var benefits = command.Benefits.Select(c => Benefit.Create(c.BenefitType, c.Amount)).ToList();
            benefitRequest.AddBenefit(benefits);

            await _benefitRequestRepository.AddAsync(benefitRequest);
            await _benefitRequestRepository.SaveChangeAsync(cancellationToken);
            return new CreateBenefitRequestCommandResponse() { Id = benefitRequest.Id };
        }
    }
}
