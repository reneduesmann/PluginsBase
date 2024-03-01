using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using PluginsBase.Enums;

namespace RD.PluginsBase.Contexts;

public class RetrieveMultipleContext : RetrieveMultipleContext<Entity>
{
    public RetrieveMultipleContext(PluginContext context) : base(context)
    {
        
    }
}

public class RetrieveMultipleContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private const string _queryKey = "Query";

    private const string _appNameKey = "x-ms-app-name";

    private const string _includeAnnotationsKey = "IncludeAnnotations";

    private const string _appModuleIdKey = "AppModuleId";

    private const string _isAppModuleContextKey = "IsAppModuleContext";

    private const string _businessEntityCollectionKey = "BusinessEntityCollection";

    private FetchExpression? _query;

    private string? _appName;

    private bool? _includeAnnotations;

    private Guid? _appModuleId;

    private bool? _isAppModuleContext;

    private EntityCollection? _businessEntityCollection;

    public virtual FetchExpression Query
    {
        get
        {
            return this._query ??= this.GetValueFromInputParameters<FetchExpression>(_queryKey, true);
        }
    }

    public virtual bool IncludeAnnotations
    {
        get
        {
            return this._includeAnnotations ??= this.GetValueFromInputParameters<bool>(_includeAnnotationsKey, true);
        }
    }

    public virtual Guid AppModuleId
    {
        get
        {
            return this._appModuleId ??= this.GetValueFromInputParameters<Guid>(_appModuleIdKey);
        }
    }

    public virtual bool IsAppModuleContext
    {
        get
        {
            return this._isAppModuleContext ??= this.GetValueFromInputParameters<bool>(_isAppModuleContextKey);
        }
    }

    public virtual string AppName
    {
        get
        {
            return this._appName ??= this.GetValueFromInputParameters<string>(_appNameKey);
        }
    }

    public virtual EntityCollection? BusinessEntityCollection
    {
        get
        {
            return this._businessEntityCollection ??= this.GetBusinessEntityCollection();
        }
    }

    public RetrieveMultipleContext(PluginContext context) : base(context)
    {
        
    }

    private EntityCollection? GetBusinessEntityCollection()
    {
        if(this.Stage != PluginStage.PostOperation)
        {
            return null;
        }

        return this.GetValueFromOutputParameters<EntityCollection>(_businessEntityCollectionKey, true);
    }
}
