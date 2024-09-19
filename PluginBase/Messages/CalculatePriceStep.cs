using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class CalculatePriceStep : PluginStep<CalculatePriceRequest, Entity>
{
    public CalculatePriceStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public CalculatePriceStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = entityName;
    }

    public CalculatePriceStep(int stage, string entityName, Action<CalculatePriceContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public CalculatePriceStep(PluginStage stage, string entityName, Action<CalculatePriceContext> action)
        : base(stage, context => action(new CalculatePriceContext(context)))
    {
        base.EntityName = entityName;
    }
}

public class CalculatePriceStep<TEntity> : PluginStep<CalculatePriceRequest, TEntity> where TEntity : Entity, new()
{
    public CalculatePriceStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public CalculatePriceStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        
    }

    public CalculatePriceStep(int stage, Action<CalculatePriceContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public CalculatePriceStep(PluginStage stage, Action<CalculatePriceContext<TEntity>> action)
        : base(stage, context => action(new CalculatePriceContext<TEntity>(context)))
    {
        
    }
}