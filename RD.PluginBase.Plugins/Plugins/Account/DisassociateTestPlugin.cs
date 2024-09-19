using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase;
using RD.PluginsBase.Contexts;
using RD.PluginsBase.Messages;

namespace RD.Plugins.Plugins;

public class DisassociateTestPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public DisassociateTestPlugin()
    {
        this.RegisteredSteps = new()
        {
            new DisassociateStep(10, DisassociateContext),
            new DisassociateStep(PluginStage.PreOperation, AssociationContext),
            new DisassociateStep(40, ExecutePluginContext)
        };
    }

    private void DisassociateContext(DisassociateContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.DisassociateContext)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"stage: {context.AppName}");
        context.TracingService.Trace($"related entities: count: {context.RelatedEntities?.Count}");
        context.TracingService.Trace($"relationship: entity role: {context.Relationship?.PrimaryEntityRole}, schema name: {context.Relationship?.SchemaName}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        
        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void AssociationContext(AssociationContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.AssociationContext)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"stage: {context.AppName}");
        context.TracingService.Trace($"related entities: count: {context.RelatedEntities?.Count}");
        context.TracingService.Trace($"relationship: entity role: {context.Relationship?.PrimaryEntityRole}, schema name: {context.Relationship?.SchemaName}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");

        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void ExecutePluginContext(PluginContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.ExecutePluginContext)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"stage: {context.Stage}");

        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void PrintInputParameters(ITracingService tracingService, IPluginExecutionContext pluginExecutionContext)
    {
        tracingService.Trace("InputParameters:");
        foreach (var inputParameter in pluginExecutionContext.InputParameters)
        {
            tracingService.Trace($"{inputParameter.Key}: {inputParameter.Value}. Type: {inputParameter.Value?.GetType()}");
        }
    }

    private void PrintOutputParameters(ITracingService tracingService, IPluginExecutionContext pluginExecutionContext)
    {
        tracingService.Trace("OutputParameters:");
        foreach (var outputParameter in pluginExecutionContext.OutputParameters)
        {
            tracingService.Trace($"{outputParameter.Key}: {outputParameter.Value}. Type: {outputParameter.Value?.GetType()}");
        }
    }
}
