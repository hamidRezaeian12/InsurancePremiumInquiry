using MediatR;

namespace InsurancePremiumInquiry.Application.Base
{
    public interface IRequestMessage : IBaseRequest
    {
    }
    public interface IRequestMessage<out TResult> : IRequestMessage, IRequest<TResult>
    {
    }
}
