using FakeXrmEasy.Abstractions;
using FakeXrmEasy.Abstractions.Enums;
using FakeXrmEasy.Middleware;
using FakeXrmEasy.Middleware.Crud;
using FakeXrmEasy.Middleware.Messages;

namespace RD.PluginBase.UnitTests;

public abstract class PluginTestBase
{
    protected IXrmFakedContext Context { get; }

    protected PluginTestBase()
    {
        this.Context = MiddlewareBuilder
            .New()
            .AddCrud()
            .AddFakeMessageExecutors()
            .UseCrud()
            .UseMessages()
            .SetLicense(FakeXrmEasyLicense.NonCommercial)
            .Build();
    }
}
