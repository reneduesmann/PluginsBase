using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class AssociationContext : PluginContext
{
    private const string _targetKey = "Target";

    private const string _relationshipKey = "Relationship";

    private const string _relatedEntitiesKey = "RelatedEntities";

    private const string _appNameKey = "x-ms-app-name";

    private EntityReference? _target;

    private Relationship? _relationship;

    private EntityReferenceCollection? _relatedEntities;

    private string? _appName;

    public virtual EntityReference Target
    {
        get
        {
            return this._target ??= this.GetValueFromInputParameters<EntityReference>(_targetKey, true);
        }
    }

    public virtual Relationship Relationship
    {
        get
        {
            return this._relationship ??= this.GetValueFromInputParameters<Relationship>(_relationshipKey, true);
        }
    }

    public virtual EntityReferenceCollection RelatedEntities
    {
        get
        {
            return this._relatedEntities ??= this.GetValueFromInputParameters<EntityReferenceCollection>(_relatedEntitiesKey, true);
        }
    }

    public virtual string AppName
    {
        get
        {
            return this._appName ??= this.GetValueFromInputParameters<string>(_appNameKey);
        }
    }

    public AssociationContext(PluginContext context) : base(context)
    {

    }
}
