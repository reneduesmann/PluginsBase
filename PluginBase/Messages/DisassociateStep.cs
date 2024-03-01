using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class DisassociateStep : PluginStep<DisassociateRequest, Entity>
{
    private const string _entityName = "none";

    public DisassociateStep(int stage, Action<PluginContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public DisassociateStep(PluginStage stage, Action<PluginContext> action)
        : base(stage, action)
    {
        base.EntityName = _entityName;
    }

    public DisassociateStep(int stage, Action<AssociationContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public DisassociateStep(PluginStage stage, Action<AssociationContext> action)
        : base(stage, context => action(new AssociationContext(context)))
    {
        base.EntityName = _entityName;
    }

    public DisassociateStep(int stage, Action<DisassociateContext> action)
        : this((PluginStage)stage, action)
    {
        
    }

    public DisassociateStep(PluginStage stage, Action<DisassociateContext> action)
        : base(stage, context => action(new DisassociateContext(context)))
    {
        base.EntityName= _entityName;
    }
}