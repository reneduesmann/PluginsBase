using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class RetrieveStep : PluginStep<RetrieveRequest, Entity>
{
    public RetrieveStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public RetrieveStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public RetrieveStep(int stage, string entityName, Action<RetrieveContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public RetrieveStep(PluginStage stage, string entityName, Action<RetrieveContext> action)
        : base(stage, context => action(new RetrieveContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class RetrieveStep<TEntity> : PluginStep<RetrieveRequest, TEntity> where TEntity : Entity, new()
{
    public RetrieveStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public RetrieveStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public RetrieveStep(int stage, Action<RetrieveContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public RetrieveStep(PluginStage stage, Action<RetrieveContext<TEntity>> action)
        : base(stage, context => action(new RetrieveContext<TEntity>(context)))
    {
        
    }
}