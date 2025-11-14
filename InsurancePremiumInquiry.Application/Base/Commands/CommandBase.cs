namespace InsurancePremiumInquiry.Application.Base.Commands
{
    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }
        public Guid CorrelationId { get; protected set; } = Guid.NewGuid();
        protected CommandBase() => Id = Guid.NewGuid();
        protected CommandBase(Guid id) => Id = id;
    }
}