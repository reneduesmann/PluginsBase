using DataverseModel;
using PluginsBase.Enums;
using RD.PluginsBase;
using RD.PluginsBase.Contexts;
using RD.PluginsBase.Messages;

namespace RD.Plugins;

public class CalculatePriceTestPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public CalculatePriceTestPlugin()
    {
        this.RegisteredSteps = new()
        {
            new CalculatePriceStep(10, "quote", ExecuteCalculatePriceContext),
            new CalculatePriceStep(PluginStage.PreOperation, "quote", ExecutePluginContext),

            new CalculatePriceStep<Quote>(20, ExecuteCalculatePriceContext)
        };
    }

    private void ExecuteCalculatePriceContext(CalculatePriceContext context)
    {

    }

    private void ExecuteCalculatePriceContext(CalculatePriceContext<Quote> context)
    {

    }

    private void ExecutePluginContext(PluginContext context)
    {

    }
}
