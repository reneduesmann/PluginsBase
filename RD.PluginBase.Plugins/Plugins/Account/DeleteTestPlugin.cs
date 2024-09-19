using DataverseModel;
using Microsoft.Xrm.Sdk;
using PluginsBase.Enums;
using RD.PluginsBase;
using RD.PluginsBase.Contexts;
using RD.PluginsBase.Messages;

namespace RD.Plugins.Plugins;

public class DeleteTestPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public DeleteTestPlugin()
    {
        this.RegisteredSteps = new()
        {
            new DeleteStep(10, "account", DeleteContextLogic),
            new DeleteStep(PluginStage.PreOperation, "account", CrudContextLogic),
            new DeleteStep(40, "account", PluginContextLogic),

            new DeleteStep<Account>(20, DeleteContextLogic),
            new DeleteStep<Account>(PluginStage.PostOperation, CrudContextLogic)
        };
    }

    private void DeleteContextLogic(DeleteContext<Account> context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.DeleteContextLogic)} with early bound");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
        context.TracingService.Trace($"stage: {context.Stage}");
        context.TracingService.Trace($"target: {context.Target?.Id} {context.Target?.LogicalName}");
        context.TracingService.Trace($"pre image: {context.PreImage?.Id} {context.PreImage?.LogicalName}");
        
        this.PrintInputParameters(context.TracingService, context.PluginExecutionContext);
        this.PrintOutputParameters(context.TracingService, context.PluginExecutionContext);
    }

    private void DeleteContextLogic(DeleteContext context)
    {
        context.TracingService.Trace($"Executiong {nameof(this.DeleteContextLogic)}");
        context.TracingService.Trace($"message: {context.Message}");
        context.TracingService.Trace($"post image key: {context.PostImageKey}");
        context.TracingService.Trace($"pre image key: {context.PreImageKey}");
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
