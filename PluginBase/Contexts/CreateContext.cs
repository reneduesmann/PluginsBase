using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class CreateContext : CreateContext<Entity>
{
    public CreateContext(PluginContext context) : base(context)
    {
        
    }
}

public class CreateContext<TEntity> : CrudContext<TEntity> where TEntity : Entity, new()
{
    public CreateContext(PluginContext context) : base(context)
    {
        
    }
}
