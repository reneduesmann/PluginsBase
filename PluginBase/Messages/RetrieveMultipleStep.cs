using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class RetrieveMultipleStep : PluginStep<RetrieveMultipleRequest, Entity>
{
    public RetrieveMultipleStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public RetrieveMultipleStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public RetrieveMultipleStep(int stage, string entityName, Action<RetrieveMultipleContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public RetrieveMultipleStep(PluginStage stage, string entityName, Action<RetrieveMultipleContext> action)
        : base(stage, context => action(new RetrieveMultipleContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class RetrieveMultipleStep<TEntity> : PluginStep<RetrieveMultipleRequest, TEntity> where TEntity : Entity, new()
{
    public RetrieveMultipleStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public RetrieveMultipleStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public RetrieveMultipleStep(int stage, Action<RetrieveMultipleContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public RetrieveMultipleStep(PluginStage stage, Action<RetrieveMultipleContext<TEntity>> action)
        : base(stage, context => action(new RetrieveMultipleContext<TEntity>(context)))
    {
        
    }
}