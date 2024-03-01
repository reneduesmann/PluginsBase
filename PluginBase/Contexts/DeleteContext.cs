using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class DeleteContext : DeleteContext<Entity>
{
    public DeleteContext(PluginContext context) : base(context)
    {
        
    }
}

public class DeleteContext<TEntity> : CrudContext<TEntity> where TEntity : Entity, new()
{
    public DeleteContext(PluginContext context) : base(context)
    {
        
    }
}
