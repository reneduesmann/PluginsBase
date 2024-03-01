using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class UpdateStep : PluginStep<UpdateRequest, Entity>
{
    public UpdateStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public UpdateStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public UpdateStep(int stage, string entityName, Action<CrudContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public UpdateStep(PluginStage stage, string entityName, Action<CrudContext> action)
        : base(stage, context => action(new CrudContext(context)))
    {
        base.EntityName = entityName;
    }

    public UpdateStep(int stage, string entityName, Action<UpdateContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public UpdateStep(PluginStage stage, string entityName, Action<UpdateContext> action)
        : base(stage, context => action(new UpdateContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class UpdateStep<TEntity> : PluginStep<UpdateRequest, TEntity> where TEntity : Entity, new()
{
    public UpdateStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public UpdateStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public UpdateStep(int stage, Action<CrudContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public UpdateStep(PluginStage stage, Action<CrudContext<TEntity>> action)
        : base(stage, context => action(new CrudContext<TEntity>(context)))
    {

    }

    public UpdateStep(int stage, Action<UpdateContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public UpdateStep(PluginStage stage, Action<UpdateContext<TEntity>> action)
        : base(stage, context => action(new UpdateContext<TEntity>(context)))
    {

    }
}