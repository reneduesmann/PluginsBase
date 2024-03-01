using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class OpportunityLoseContext : OpportunityLoseContext<Entity>
{
    public OpportunityLoseContext(PluginContext context) : base(context)
    {
        
    }
}

public class OpportunityLoseContext<TEntity> : OpportunityDecisionContext<TEntity> where TEntity : Entity, new()
{
    public OpportunityLoseContext(PluginContext context) : base(context)
    {
        
    }
}
