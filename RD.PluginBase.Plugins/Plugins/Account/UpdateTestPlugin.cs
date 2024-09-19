using DataverseModel;
using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase;
using RD.PluginsBase.Contexts;
using RD.PluginsBase.Messages;

namespace RD.Plugins.Plugins;

public class UpdateTestPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public UpdateTestPlugin()
    {
        this.RegisteredSteps = new()
        {
            new UpdateStep(10, "account", UpdateContextLogic),
            new UpdateStep(PluginStage.PreOperation, "account", CrudContextLogic),
            new UpdateStep(40, "account", PluginContextLogic),

            new UpdateStep<Account>(20, UpdateContextLogic),
            new UpdateStep<Account>(PluginStage.PostOperation, CrudContextLogic)
        };
    }

    private void UpdateContextLogic(UpdateContext<Account> context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.UpdateContextLogic)} with early bound");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"concurrency behavior: {context.ConcurrencyBehavior}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        context.TracingService.Trace($"pre image: {context.PreImage?.Id} {context.PreImage?.LogicalName}");
        
        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void UpdateContextLogic(UpdateContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.UpdateContextLogic)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
        context.TracingService.Trace($"concurrency behavior: {context.ConcurrencyBehavior}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        context.TracingService.Trace($"pre image: {context.PreImage?.Id} {context.PreImage?.LogicalName}");

        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void PluginContextLogic(PluginContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.PluginContextLogic)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"stage: {context.Stage}");

        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void CrudContextLogic(CrudContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.CrudContextLogic)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        context.TracingService.Trace($"pre image: {context.PreImage?.Id} {context.PreImage?.LogicalName}");

        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void CrudContextLogic(CrudContext<Account> context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.CrudContextLogic)} with early bound");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        context.TracingService.Trace($"pre image: {context.PreImage?.Id} {context.PreImage?.LogicalName}");

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
