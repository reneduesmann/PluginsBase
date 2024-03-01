using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class AssociateStep : PluginStep<AssociateRequest, Entity>
{
    private const string _entityName = "none";

    public AssociateStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public AssociateStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = _entityName;
    }

    public AssociateStep(int stage, Action<AssociationContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public AssociateStep(PluginStage stage, Action<AssociationContext> action)
        : base(stage, context => action(new AssociationContext(context)))
    {
        base.EntityName = _entityName;
    }

    public AssociateStep(int stage, Action<AssociateContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public AssociateStep(PluginStage stage, Action<AssociateContext> action)
        : base(stage, context => action(new AssociateContext(context)))
    {
        base.EntityName = _entityName;
    }
}