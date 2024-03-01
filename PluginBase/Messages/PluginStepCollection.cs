using PluginsBase.Enums;
using RD.PluginsBase.Contexts;

namespace RD.PluginsBase.Messages;

public class PluginStepCollection : List<PluginStep>
{
    public void Add((int stage, string message, string entityName, Action<PluginContext> action) item)
    {
        (int stage, string message, string entityName, Action<PluginContext> action) = item;

        base.Add(new(stage, message, entityName, action));
    }

    public void Add(Tuple<int, string, string, Action<PluginContext>> item)
    {
        (int stage, string message, string entityName, Action<PluginContext> action) = item;

        base.Add(new(stage, message, entityName, action));
    }

    public void Add(int stage, string message, string entityName, Action<PluginContext> action)
    {
        base.Add(new(stage, message, entityName, action));
    }

    public void Add(PluginStage stage, string message, string entityName, Action<PluginContext> action)
    {
        base.Add(new(stage, message, entityName, action));
    }

    public void Add(PluginStage stage, PluginMessage message, string entityName, Action<PluginContext> action)
    {
        base.Add(new(stage, message, entityName, action));
    }
}
