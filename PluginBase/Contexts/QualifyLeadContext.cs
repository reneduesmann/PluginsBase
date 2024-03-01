using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;

namespace RD.PluginsBase.Contexts;

public class QualifyLeadContext : PluginContext
{
    private const string _createAccountKey = "CreateAccount";

    private const string _createContactKey = "CreateContact";

    private const string _createOpportunityKey = "CreateOpportunity";

    private const string _opportunityCurrencyIdKey = "OpportunityCurrencyId";

    private const string _opportunityCustomerIdKey = "OpportunityCustomerId";

    private const string _statusKey = "Status";

    private const string _suppressDuplicateDetectionKey = "SuppressDuplicateDetection";

    private const string _leadIdKey = "LeadId";

    private const string _appNameKey = " x-ms-app-name";

    private const string _sourceCampaignIdKey = "SourceCampaignId";

    private const string _processInstanceIdKey = "ProcessInstanceId";

    private const string _createdEntitiesKey = "CreatedEntities";

    private bool? _createAccount;

    private bool? _createContact;

    private bool? _createOpportunity;

    private EntityReference? _opportunityCurrencyId;

    private EntityReference? _opportunityCustomerId;

    private OptionSetValue? _status;

    private bool? _suppressDuplicateDetection;

    private EntityReference? _leadId;

    private string? _appName;

    private EntityReference? _sourceCampaignId;

    private EntityReference? _processInstanceId;

    private EntityReferenceCollection? _createdEntities;

    public virtual bool CreateAccount
    {
        get
        {
            return this._createAccount ??= this.GetValueFromInputParameters<bool>(_createAccountKey);
        }
    }

    public virtual bool CreateContact
    {
        get
        {
            return this._createContact ??= this.GetValueFromInputParameters<bool>(_createContactKey);
        }
    }

    public virtual bool CreateOpportunity
    {
        get
        {
            return this._createOpportunity ??= this.GetValueFromInputParameters<bool>(_createOpportunityKey);
        }
    }

    public virtual EntityReference OpportunityCurrencyId
    {
        get
        {
            return this._opportunityCurrencyId ??= this.GetValueFromInputParameters<EntityReference>(_opportunityCurrencyIdKey);
        }
    }

    public virtual EntityReference OpportunityCustomerId
    {
        get
        {
            return this._opportunityCustomerId ??= this.GetValueFromInputParameters<EntityReference>(_opportunityCustomerIdKey);
        }
    }

    public virtual OptionSetValue Status
    {
        get
        {
            return this._status ??= this.GetValueFromInputParameters<OptionSetValue>(_statusKey, true);
        }
    }

    public virtual bool SuppressDuplicateDetection
    {
        get
        {
            return this._suppressDuplicateDetection ??= this.GetValueFromInputParameters<bool>(_suppressDuplicateDetectionKey);
        }
    }

    public virtual EntityReference LeadId
    {
        get
        {
            return this._leadId ??= this.GetValueFromInputParameters<EntityReference>(_leadIdKey, true);
        }
    }

    public virtual string AppName
    {
        get
        {
            return this._appName ??= this.GetValueFromInputParameters<string>(_appNameKey);
        }
    }

    public virtual EntityReference? SourceCampaignId
    {
        get
        {
            return this._sourceCampaignId ??= this.GetValueFromInputParameters<EntityReference>(_sourceCampaignIdKey);
        }
    }

    public virtual EntityReference? ProcessInstanceId
    {
        get
        {
            return this._processInstanceId ??= this.GetValueFromInputParameters<EntityReference>(_processInstanceIdKey);
        }
    }

    public virtual EntityReferenceCollection? CreatedEntities
    {
        get
        {
            return this._createdEntities ??= this.GetCreatedEntities();
        }
    }

    public QualifyLeadContext(PluginContext context) : base(context)
    {

    }

    private EntityReferenceCollection? GetCreatedEntities()
    {
        if (this.Stage != PluginStage.PostOperation)
        {
            return null;
        }

        return this.GetValueFromOutputParameters<EntityReferenceCollection>(_createdEntitiesKey, true);
    }
}
