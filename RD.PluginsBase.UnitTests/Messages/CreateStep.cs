using FakeXrmEasy.Plugins;
using Microsoft.Xrm.Sdk;
using RD.Plugins.Plugins;
using System;

namespace RD.PluginBase.UnitTests.Messages;

public class CreateStep : PluginTestBase
{
    public CreateStep()
    {

    }

    [Fact]
    public void CrudContextLogic_TraceTheContext_ShouldTraceEverythingCorrect()
    {
        // Arrange

        Entity target = new()
        {
            LogicalName = "account"
        };

        // Act

        base.Context.ExecutePluginWithTarget<CreateTestPlugin>(target, "Create", 20);

        // Assert

        string trace = base.Context.GetTracingService().DumpTrace();

        Assert.Contains("Executiong CrudContextLogic", trace);
        Assert.Contains("message: Create", trace);
        Assert.Contains("post image key: postimage", trace);
        Assert.Contains("pre image key: preimage", trace);
        Assert.Contains("stage: PreOperation", trace);
        Assert.Contains("target: 00000000-0000-0000-0000-000000000000 account", trace);
        Assert.Contains("pre image: 00000000-0000-0000-0000-000000000000", trace);
    }

    [Fact]
    public void CreateContextLogic_TraceTheContext_ShouldTraceEverythingCorrect()
    {
        // Arrange

        Entity target = new()
        {
            LogicalName = "contact"
        };

        // Act

        base.Context.ExecutePluginWithTarget<CreateTestPlugin>(target, "Create", 20);

        // Assert

        string trace = base.Context.GetTracingService().DumpTrace();

        Assert.Contains("Executiong CreateContextLogic", trace);
        Assert.Contains("message: Create", trace);
        Assert.Contains("post image key: postimage", trace);
        Assert.Contains("pre image key: preimage", trace);
        Assert.Contains("stage: PreOperation", trace);
        Assert.Contains("target: 00000000-0000-0000-0000-000000000000 contact", trace);
        Assert.Contains("pre image: 00000000-0000-0000-0000-000000000000", trace);

    }

    [Fact]
    public void PluginContextLogic_TraceTheContext_ShouldTraceEverythingCorrect()
    {
        // Arrange

        Entity target = new()
        {
            LogicalName = "lead"
        };

        // Act

        base.Context.ExecutePluginWithTarget<CreateTestPlugin>(target, "Create", 20);

        // Assert

        string trace = base.Context.GetTracingService().DumpTrace();

        Assert.Contains("Executiong PluginContextLogic", trace);
        Assert.Contains("message: Create", trace);
        Assert.Contains("stage: PreOperation", trace);
    }
}
