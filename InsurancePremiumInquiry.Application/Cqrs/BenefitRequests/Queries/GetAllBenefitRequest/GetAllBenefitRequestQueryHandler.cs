using InsurancePremiumInquiry.Application.Base.Queries;
using InsurancePremiumInquiry.Application.Dto.BenefitRequests;
using InsurancePremiumInquiry.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Queries.GetAllBenefitRequest
{
    public class GetAllBenefitRequestQueryHandler : QueryHandlerBase<GetAllBenefitRequestQuery, GetAllBenefitRequestQueryResponse>
    {
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        public GetAllBenefitRequestQueryHandler(ILoggerFactory loggerFactory,
                                                IBenefitRequestRepository benefitRequestRepository) : base(loggerFactory)
        {
            _benefitRequestRepository = benefitRequestRepository;
        }
        protected override async Task<GetAllBenefitRequestQueryResponse> Batch(GetAllBenefitRequestQuery query, CancellationToken cancellationToken = default)
        {
            var benefitRequetsts = await _benefitRequestRepository.GetAllAsync();
            var response= benefitRequetsts.Select(c=>new BenefitRequestOutputDto()
            {
                Id = c.Id,
                Title = c.Title,
                Benefits= [.. c.Benefits.Select(c=>new BenefitOutputDto()
                {
                    Id=c.Id,
                    Amount=c.Amount,
                    BenefitType=c.BenefitType,
                    MaxAmount=c.MaxAmount,
                    MinAmount=c.MinAmount,
                    Name=c.Name,
                })]
            });
            return new GetAllBenefitRequestQueryResponse()
            {
                BenefitRequests = response.ToList()
            };
        }
    }
}
