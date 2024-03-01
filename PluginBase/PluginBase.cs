using Microsoft.Xrm.Sdk;
using RD.PluginsBase.Contexts;
using RD.PluginsBase.Messages;
using System.Diagnostics;

namespace RD.PluginsBase;

public abstract class PluginBase : IPlugin
{
    public abstract PluginStepCollection RegisteredSteps { get; }

    public void Execute(IServiceProvider serviceProvider)
    {
        if(serviceProvider is null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        this.Execute(new PluginContext(serviceProvider));
    }

    public void Execute(PluginContext context)
    {
        context.Trace($"Executing plugin: {this.GetType().Name}.");
        Stopwatch stopwatch = Stopwatch.StartNew();

        IEnumerable<PluginStep> stepsToExecute = this.RegisteredSteps.Where(x => x.CanExecute(context));

        try
        {
            foreach (PluginStep pluginStep in stepsToExecute)
            {
                pluginStep.Execute(context);
            }
        }
        catch (Exception ex)
        {
            context.Trace($"Error occurred while executing plugin. {ex.Message}.");
            throw;
        }
        finally
        {
            stopwatch.Stop();
            context.Trace($"Executed plugin: {this.GetType().Name} in {stopwatch.Elapsed.TotalSeconds} seconds.");
        }
    }
}