using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class OpportunityDecisionContext : OpportunityDecisionContext<Entity>
{
    public OpportunityDecisionContext(PluginContext context) : base(context)
    {
        
    }
}

public class OpportunityDecisionContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private const string _opportunityCloseKey = "OpportunityClose";

    private const string _statusKey = "Status";

    private const string _callerKey = "Caller";

    private Entity? _opportunityClose;

    private OptionSetValue? _status;

    private string? _caller;

    public virtual Entity OpportunityClose
    {
        get
        {
            return this._opportunityClose ??= this.GetValueFromInputParameters<Entity>(_opportunityCloseKey, true);
        }
    }

    public virtual OptionSetValue Status
    {
        get
        {
            return this._status ??= this.GetValueFromInputParameters<OptionSetValue>(_statusKey, true);
        }
    }

    public virtual string Caller
    {
        get
        {
            return this._caller ??= this.GetValueFromInputParameters<string>(_callerKey);
        }
    }

    public OpportunityDecisionContext(PluginContext context) : base(context)
    {
        
    }
}
