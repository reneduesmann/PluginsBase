using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class MergeContext : MergeContext<Entity>
{
    public MergeContext(PluginContext context) : base(context)
    {
        
    }
}

public class MergeContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private const string _targetKey = "Target";

    private const string _subordinateIdKey = "SubordinateId";

    private const string _performParentingChecksKey = "PerformParentingChecks";

    private const string _appNameKey = "x-ms-app-name";

    private EntityReference? _target;

    private Guid? _subordinateId;

    private bool? _performParentingChecks;

    private string? _appName;

    public virtual EntityReference Target
    {
        get
        {
            return this._target ??= this.GetValueFromInputParameters<EntityReference>(_targetKey, true);
        }
    }

    public virtual Guid SubordinateId
    {
        get
        {
            return this._subordinateId ??= this.GetValueFromInputParameters<Guid>(_subordinateIdKey);
        }
    }

    public virtual bool PerformParentingChecks
    {
        get
        {
            return this._performParentingChecks ??= this.GetValueFromInputParameters<bool>(_performParentingChecksKey);
        }
    }

    public virtual string AppName
    {
        get
        {
            return this._appName ??= this.GetValueFromInputParameters<string>(_appNameKey);
        }
    }

    public MergeContext(PluginContext context) : base(context)
    {

    }
}
