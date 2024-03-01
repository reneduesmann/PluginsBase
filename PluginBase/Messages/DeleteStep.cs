using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class DeleteStep : PluginStep<DeleteRequest, Entity>
{
    public DeleteStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public DeleteStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public DeleteStep(int stage, string entityName, Action<CrudContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public DeleteStep(PluginStage stage, string entityName, Action<CrudContext> action)
        : base(stage, context => action(new CrudContext(context)))
    {
        base.EntityName = entityName;
    }

    public DeleteStep(int stage, string entityName, Action<DeleteContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public DeleteStep(PluginStage stage, string entityName, Action<DeleteContext> action)
        : base(stage, context => action(new DeleteContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class DeleteStep<TEntity> : PluginStep<DeleteRequest, TEntity> where TEntity : Entity, new()
{
    public DeleteStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public DeleteStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public DeleteStep(int stage, Action<CrudContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public DeleteStep(PluginStage stage, Action<CrudContext<TEntity>> action)
        : base(stage, context => action(new CrudContext<TEntity>(context)))
    {

    }

    public DeleteStep(int stage, Action<DeleteContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public DeleteStep(PluginStage stage, Action<DeleteContext<TEntity>> action)
        : base(stage, context => action(new DeleteContext<TEntity>(context)))
    {

    }
}