using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class UpdateContext : UpdateContext<Entity>
{
    public UpdateContext(PluginContext context) : base(context)
    {

    }
}

public class UpdateContext<TEntity> : CrudContext<TEntity> where TEntity : Entity, new()
{
    private const string _concurrencyBehaviorKey = "ConcurrencyBehavior";

    private ConcurrencyBehavior? _concurrencyBehavior;

    public virtual ConcurrencyBehavior? ConcurrencyBehavior
    {
        get
        {
            return this._concurrencyBehavior ??= this.GetConcurrencyBehavior();
        }
    }

    public UpdateContext(PluginContext context) : base(context)
    {
        
    }

    private ConcurrencyBehavior? GetConcurrencyBehavior()
    {
        if(!this.PluginExecutionContext.InputParameters.TryGetValue(_concurrencyBehaviorKey, out object concurrencyBehavior))
        {
            return null;
        }

        if(concurrencyBehavior is ConcurrencyBehavior behavior)
        {
            return behavior;
        }

        if(concurrencyBehavior is string  concurrencyBehaviorName)
        {
            if(Enum.TryParse(concurrencyBehaviorName, true, out ConcurrencyBehavior result))
            {
                return result;
            }
        }

        return null;
    }
}
