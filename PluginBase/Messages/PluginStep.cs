using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class PluginStep
{
    public virtual PluginStage Stage { get; }

    public virtual string Message { get; protected set; }

    public virtual string EntityName { get; protected set; }

    public virtual Action<PluginContext> Action { get; }

    public PluginStep(int stage, string message, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, message, entityName, action)
    {

    }

    public PluginStep(PluginStage stage, string message, string entityName, Action<PluginContext> action)
    {
        Stage = stage;
        Message = message;
        EntityName = entityName;
        Action = action;
    }

    public PluginStep(PluginStage stage, PluginMessage message, string entityName, Action<PluginContext> action)
        : this(stage, message.ToString(), entityName, action)
    {

    }

    public void Execute(PluginContext context)
    {
        Action?.Invoke(context);
    }

    public virtual bool CanExecute(PluginContext context)
    {
        if (string.IsNullOrWhiteSpace(Message) || string.IsNullOrWhiteSpace(EntityName) || Action is null)
        {
            return false;
        }

        if (!EntityName.Equals(context.PluginExecutionContext.PrimaryEntityName, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (!Message.Equals(context.Message, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (Stage != context.Stage)
        {
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        return $"Message: {Message ?? "null"}, " +
            $"Stage: {Stage}, " +
            $"EntityName: {EntityName ?? "null"}, " +
            $"Action: {Action?.Method?.Name ?? "null"}.";
    }
}

public class PluginStep<TEntity> : PluginStep where TEntity : Entity, new()
{
    private string? _entityLogicalName = string.Empty;

    public PluginStep(int stage, string message, Action<PluginContext> action)
        : this((PluginStage)stage, message, action)
    {

    }

    public PluginStep(PluginStage stage, string message, Action<PluginContext> action)
        : base(stage, message, string.Empty, action)
    {
        SetEntityName();
    }

    public PluginStep(PluginStage stage, PluginMessage message, Action<PluginContext> action)
        : this(stage, message.ToString(), action)
    {

    }

    private void SetEntityName()
    {
        _entityLogicalName = (typeof(TEntity)
            .GetCustomAttributes(typeof(EntityLogicalNameAttribute), false)
            .FirstOrDefault() as EntityLogicalNameAttribute)
            ?.LogicalName;

        base.EntityName = _entityLogicalName ?? string.Empty;
    }
}

public class PluginStep<TRequest, TEntity> : PluginStep<TEntity>
    where TRequest : OrganizationRequest, new()
    where TEntity : Entity, new()
{
    private static readonly string _requestName;

    static PluginStep()
    {
        TRequest request = new();
        _requestName = request.RequestName;
    }

    public PluginStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {

    }

    public PluginStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, _requestName, action)
    {

    }
}