using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class QualifyLeadStep : PluginStep<QualifyLeadRequest, Entity>
{
    private const string _entityName = "lead";

    public QualifyLeadStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public QualifyLeadStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = _entityName;
    }

    public QualifyLeadStep(int stage, Action<QualifyLeadContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public QualifyLeadStep(PluginStage stage, Action<QualifyLeadContext> action)
        : base(stage, context => action(new QualifyLeadContext(context)))
    {
        base.EntityName = _entityName;
    }
}