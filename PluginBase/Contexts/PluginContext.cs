using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.PluginTelemetry;
using PluginsBase.Enums;

namespace RD.PluginsBase.Contexts;

public class PluginContext
{
    public PluginStage Stage { get; }

    public string Message { get; }

    public IOrganizationService OrganizationService { get; }

    public IOrganizationService AdminOrganizationService { get; }

    public IPluginExecutionContext PluginExecutionContext { get; }

    public ITracingService TracingService { get; }

    private readonly IOrganizationServiceFactory _organizationServiceFactory;

    public PluginContext(IServiceProvider serviceProvider)
    {
        if (serviceProvider is null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        this.PluginExecutionContext = serviceProvider.GetService<IPluginExecutionContext>();
        this.TracingService = serviceProvider.GetService<ITracingService>();

        this._organizationServiceFactory = serviceProvider.GetService<IOrganizationServiceFactory>();

        this.OrganizationService = _organizationServiceFactory.CreateOrganizationService(this.PluginExecutionContext.UserId);
        this.AdminOrganizationService = _organizationServiceFactory.CreateOrganizationService(null);

        this.Stage = (PluginStage)this.PluginExecutionContext.Stage;
        this.Message = this.PluginExecutionContext.MessageName;
    }

    public PluginContext(PluginContext context)
    {
        this.PluginExecutionContext = context.PluginExecutionContext ?? throw new ArgumentNullException(nameof(context.PluginExecutionContext));
        this.TracingService = context.TracingService ?? throw new ArgumentNullException(nameof(context.TracingService));
        this._organizationServiceFactory = context._organizationServiceFactory ?? throw new ArgumentNullException(nameof(context._organizationServiceFactory));
        this.OrganizationService = context.OrganizationService ?? throw new ArgumentNullException(nameof(context.OrganizationService));
        this.AdminOrganizationService = context.AdminOrganizationService ?? throw new ArgumentNullException(nameof(context.AdminOrganizationService));
        this.Stage = context.Stage;
        this.Message = context.Message ?? throw new ArgumentNullException(nameof(context.Message));
    }

    public IOrganizationService GetOrganizationServiceForUser(Guid userId)
    {
        return userId == Guid.Empty
            ? throw new ArgumentNullException(nameof(userId))
            : this._organizationServiceFactory.CreateOrganizationService(userId);
    }

    public void Trace(string message, LogLevel logLevel = LogLevel.Information)
    {
        string messageToLog = string.Format("[{0}] [{1}] - {2}",
            DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), logLevel, message);

        this.TracingService?.Trace(messageToLog);
    }

    protected TType GetValueFromInputParameters<TType>(string key, bool throwExceptionIfNull = false)
    {
        this.PluginExecutionContext.InputParameters.TryGetValue(key, out TType value);

        if (throwExceptionIfNull && value is null)
        {
            throw new ArgumentException($"Unable to retrieve {key} from context.");
        }

        return value;
    }

    protected TType GetValueFromOutputParameters<TType>(string key, bool throwExceptionIfNull = false)
    {
        this.PluginExecutionContext.OutputParameters.TryGetValue(key, out TType value);

        if (throwExceptionIfNull && value is null)
        {
            throw new ArgumentException($"Unable to retrieve {key} from context.");
        }

        return value;
    }
}