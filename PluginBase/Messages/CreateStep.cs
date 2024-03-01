using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class CreateStep : PluginStep<CreateRequest, Entity>
{
    public CreateStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public CreateStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public CreateStep(int stage, string entityName, Action<CrudContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public CreateStep(PluginStage stage, string entityName, Action<CrudContext> action)
        : base(stage, context => action(new CrudContext(context)))
    {
        base.EntityName = entityName;
    }

    public CreateStep(int stage, string entityName, Action<CreateContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public CreateStep(PluginStage stage, string entityName, Action<CreateContext> action)
        : base(stage, context => action(new CreateContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class CreateStep<TEntity> : PluginStep<CreateRequest, TEntity> where TEntity : Entity, new()
{
    public CreateStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public CreateStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public CreateStep(int stage, Action<CrudContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public CreateStep(PluginStage stage, Action<CrudContext<TEntity>> action)
        : base(stage, context => action(new CrudContext<TEntity>(context)))
    {

    }

    public CreateStep(int stage, Action<CreateContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public CreateStep(PluginStage stage, Action<CreateContext<TEntity>> action)
        : base(stage, context => action(new CreateContext<TEntity>(context)))
    {

    }
}