using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class MergeStep : PluginStep<MergeRequest, Entity>
{
    public MergeStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public MergeStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public MergeStep(int stage, string entityName, Action<MergeContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public MergeStep(PluginStage stage, string entityName, Action<MergeContext> action)
        : base(stage, context => action(new MergeContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class MergeStep<TEntity> : PluginStep<MergeRequest, TEntity> where TEntity : Entity, new()
{
    public MergeStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public MergeStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public MergeStep(int stage, Action<MergeContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public MergeStep(PluginStage stage, Action<MergeContext<TEntity>> action)
        : base(stage, context => action(new MergeContext<TEntity>(context)))
    {
        
    }
}