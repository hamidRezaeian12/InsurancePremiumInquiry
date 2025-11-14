namespace InsurancePremiumInquiry.Application.Base.Queries
{
    public interface IQuery<out TResult> : IRequestMessage, IRequestMessage<TResult>
    {
        Guid Id { get; }
    }
}