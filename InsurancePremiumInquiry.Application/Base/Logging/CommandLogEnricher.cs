using InsurancePremiumInquiry.Application.Base.Commands;
using Serilog.Core;
using Serilog.Events;

namespace InsurancePremiumInquiry.Application.Base.Logging
{
    public class CommandLogEnricher : ILogEventEnricher
    {
        private readonly ICommand command;
        private readonly bool decorated;
        public CommandLogEnricher(ICommand command) : this(command, false)
        {
        }
        public CommandLogEnricher(ICommand command, bool decorated)
        {
            this.command = command;
            this.decorated = decorated;
        }
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"{(decorated ? "Decorated, " : string.Empty)}Command-{command.GetType()}")));
            logEvent.AddOrUpdateProperty(new LogEventProperty("CommandId", new ScalarValue(command.Id)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(ICommand.CorrelationId), new ScalarValue(command.CorrelationId)));
        }
    }
}
