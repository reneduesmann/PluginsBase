using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class OpportunityWinContext : OpportunityWinContext<Entity>
{
    public OpportunityWinContext(PluginContext context) : base(context)
    {
        
    }
}

public class OpportunityWinContext<TEntity> : OpportunityDecisionContext<TEntity> where TEntity : Entity, new()
{
    public OpportunityWinContext(PluginContext context) : base(context)
    {
        
    }
}
