using InsurancePremiumInquiry.Application.Base.Logging;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace InsurancePremiumInquiry.Application.Base.Commands
{
    public abstract class CommandHandlerBase<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        protected ILogger Logger { get; }
        protected CommandHandlerBase(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(GetType());

        }
        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default)
        {
            using (LogContext.Push(new CommandLogEnricher(command)))
            {
                try
                {
                    var rtn = await Batch(command, cancellationToken);
                    return rtn;
                }
                catch (Exception exception)
                {
                    Logger.LogError(exception, $"CommandHandler({GetType()}): Unexpected error: {exception.Message}");
                    throw;
                }
            }
        }
        protected abstract Task<TResult> Batch(TCommand command, CancellationToken cancellationToken = default);
    }
}
