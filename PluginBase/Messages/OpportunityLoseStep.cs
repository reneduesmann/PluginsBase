using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class OpportunityLoseStep : PluginStep
{
    private const string _message = "Lose";

    public OpportunityLoseStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public OpportunityLoseStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, _message, entityName, action)
    {
        
    }

    public OpportunityLoseStep(int stage, string entityName, Action<OpportunityDecisionContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public OpportunityLoseStep(PluginStage stage, string entityName, Action<OpportunityDecisionContext> action)
        : base(stage, _message, entityName, context => action(new OpportunityDecisionContext(context)))
    {
        
    }

    public OpportunityLoseStep(int stage, string entityName, Action<OpportunityLoseContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public OpportunityLoseStep(PluginStage stage, string entityName, Action<OpportunityLoseContext> action)
        : base(stage, _message, entityName, context => action(new OpportunityLoseContext(context)))
    {
        
    }
}

public class OpportunityLoseStep<TEntity> : PluginStep<TEntity> where TEntity : Entity, new()
{
    private const string _message = "Lose";

    public OpportunityLoseStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {

    }

    public OpportunityLoseStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, _message, action)
    {
        
    }

    public OpportunityLoseStep(int stage, Action<OpportunityDecisionContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public OpportunityLoseStep(PluginStage stage, Action<OpportunityDecisionContext<TEntity>> action)
        : base(stage, _message, context => action(new OpportunityDecisionContext<TEntity>(context)))
    {
        
    }

    public OpportunityLoseStep(int stage, Action<OpportunityLoseContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public OpportunityLoseStep(PluginStage stage, Action<OpportunityLoseContext<TEntity>> action)
        : base(stage, _message, context => action(new OpportunityLoseContext<TEntity>(context)))
    {
        
    }
}