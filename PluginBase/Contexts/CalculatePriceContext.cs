using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class CalculatePriceContext : CalculatePriceContext<Entity>
{
    public CalculatePriceContext(PluginContext context) : base(context)
    {
        
    }
}

public class CalculatePriceContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private const string _targetKey = "Target";

    private const string _parentIdKey = "ParentId";

    private EntityReference? _target;

    private Guid? _parentId;

    public virtual EntityReference Target
    {
        get
        {
            return this._target ??= this.GetValueFromInputParameters<EntityReference>(_targetKey, true);
        }
    }

    public virtual Guid ParentId
    {
        get
        {
            return this._parentId ??= this.GetValueFromInputParameters<Guid>(_parentIdKey);
        }
    }

    public CalculatePriceContext(PluginContext context) : base(context)
    {

    }
}