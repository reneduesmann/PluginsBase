using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class OpportunityWinStep : PluginStep
{
    private const string _message = "Win";

    public OpportunityWinStep(int stage, string entityName, Action<PluginContext> action)
        : this((PluginStage)stage, entityName, action)
    {
        
    }

    public OpportunityWinStep(PluginStage stage, string entityName, Action<PluginContext> action)
        : base(stage, _message, entityName, action)
    {
        
    }

    public OpportunityWinStep(int stage, string entityName, Action<OpportunityDecisionContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public OpportunityWinStep(PluginStage stage, string entityName, Action<OpportunityDecisionContext> action)
        : base(stage, _message, entityName, context => action(new OpportunityDecisionContext(context)))
    {

    }

    public OpportunityWinStep(int stage, string entityName, Action<OpportunityWinContext> action)
        : this((PluginStage)stage, entityName, action)
    {

    }

    public OpportunityWinStep(PluginStage stage, string entityName, Action<OpportunityWinContext> action)
        : base(stage, _message, entityName, context => action(new OpportunityWinContext(context)))
    {

    }
}

public class OpportunityWinStep<TEntity> : PluginStep<TEntity> where TEntity : Entity, new()
{
    private const string _message = "Win";

    public OpportunityWinStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public OpportunityWinStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, _message, action)
    {
        
    }

    public OpportunityWinStep(int stage, Action<OpportunityDecisionContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public OpportunityWinStep(PluginStage stage, Action<OpportunityDecisionContext<TEntity>> action)
        : base(stage, _message, context => action(new OpportunityDecisionContext<TEntity>(context)))
    {

    }

    public OpportunityWinStep(int stage, Action<OpportunityWinContext<TEntity>> action)
        : this((PluginStage)stage, action)
    {

    }

    public OpportunityWinStep(PluginStage stage, Action<OpportunityWinContext<TEntity>> action)
        : base(stage, _message, context => action(new OpportunityWinContext<TEntity>(context)))
    {

    }
}