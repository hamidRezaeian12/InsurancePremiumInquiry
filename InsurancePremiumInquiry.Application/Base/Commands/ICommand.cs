namespace InsurancePremiumInquiry.Application.Base.Commands
{
    public interface ICommand
    {
        Guid CorrelationId { get; }
        Guid Id { get; }
    }
    public interface ICommand<out TResult> : ICommand, IRequestMessage<TResult>
    {
    }
}
