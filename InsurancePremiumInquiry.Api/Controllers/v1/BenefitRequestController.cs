using Asp.Versioning;
using InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Commands.CreateBenefitRequest;
using InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Queries.GetAllBenefitRequest;
using InsurancePremiumInquiry.Application.Dto.BenefitRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePremiumInquiry.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BenefitRequestController : ControllerBase
    {
        private readonly ISender _sender;
        public BenefitRequestController(ISender sender) => _sender = sender;
        [HttpGet]
        [MapToApiVersion("1.0")]
        public Task<GetAllBenefitRequestQueryResponse> GetAll(CancellationToken cancellationToken = default)
        => _sender.Send(new GetAllBenefitRequestQuery(), cancellationToken);

        [HttpPost]
        [MapToApiVersion("1.0")]
        public Task<CreateBenefitRequestCommandResponse> Post([FromBody] BenefitRequestInputDto dto, CancellationToken cancellationToken = default)
        => _sender.Send(new CreateBenefitRequestCommand(dto.Title, dto.Benefit), cancellationToken);
    }
}
