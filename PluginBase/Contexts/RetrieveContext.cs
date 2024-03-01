using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using PluginsBase.Enums;

namespace RD.PluginsBase.Contexts;

public class RetrieveContext : RetrieveContext<Entity>
{
    public RetrieveContext(PluginContext context) : base(context)
    {
        
    }
}

public class RetrieveContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private const string _targetKey = "Target";

    private const string _columnSetKey = "ColumnSet";

    private const string _relatedEntitiesQueryKey = "RelatedEntitiesQuery";

    private const string _returnNotificationsKey = "ReturnNotifications";

    private const string _appNameKey = "x-ms-app-name";

    private const string _includeAnnotationsKey = "IncludeAnnotations";

    private const string _businessEntityKey = "BusinessEntity";

    private EntityReference? _target;

    private ColumnSet? _columnSet;

    private RelationshipQueryCollection? _relatedEntitiesQuery;

    private bool? _returnNotifications;

    private string? _appName;

    private bool? _includeAnnotations;

    private Entity? _businessEntity;

    public virtual EntityReference Target
    {
        get
        {
            return this._target ??= this.GetValueFromInputParameters<EntityReference>(_targetKey, true);
        }
    }

    public virtual ColumnSet ColumnSet
    {
        get
        {
            return this._columnSet ??= this.GetValueFromInputParameters<ColumnSet>(_columnSetKey, true);
        }
    }

    public virtual RelationshipQueryCollection RelatedEntitiesQuery
    {
        get
        {
            return this._relatedEntitiesQuery ??= this.GetValueFromInputParameters<RelationshipQueryCollection>(_relatedEntitiesQueryKey,  true);
        }
    }

    public virtual bool ReturnNotifications
    {
        get
        {
            return this._returnNotifications ??= this.GetValueFromInputParameters<bool>(_returnNotificationsKey);
        }
    }

    public virtual string AppName
    {
        get
        {
            return this._appName ??= this.GetValueFromInputParameters<string>(_appNameKey);
        }
    }

    public virtual bool IncludeAnnotations
    {
        get
        {
            return this._includeAnnotations ??= this.GetValueFromInputParameters<bool>(_includeAnnotationsKey);
        }
    }

    public virtual Entity? BusinessEntity
    {
        get
        {
            return this._businessEntity ??= this.GetBusinessEntity();
        }
    }

    public RetrieveContext(PluginContext context) : base(context)
    {
        
    }

    private Entity? GetBusinessEntity()
    {
        if (this.Stage != PluginStage.PostOperation)
        {
            return null;
        }

        return this.GetValueFromOutputParameters<Entity>(_businessEntityKey, true);
    }
}
