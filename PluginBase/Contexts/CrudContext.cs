using Microsoft.Xrm.Sdk;

namespace RD.PluginsBase.Contexts;

public class CrudContext : CrudContext<Entity>
{
    public CrudContext(PluginContext context) : base(context)
    {

    }
}

public class CrudContext<TEntity> : PluginContext where TEntity : Entity, new()
{
    private TEntity? _target;

    private TEntity? _preImage;

    private TEntity? _postImage;

    public virtual string PreImageKey { get; } = "preimage";

    public virtual string PostImageKey { get; } = "postimage";

    public virtual TEntity Target
    {
        get
        {
            return this._target ??= this.GetTarget();
        }
    }

    public virtual TEntity PreImage
    {
        get
        {
            return this._preImage ??= this.GetPreImage();
        }
    }

    public virtual TEntity PostImage
    {
        get
        {
            return this._postImage ??= this.GetPostImage();
        }
    }

    public CrudContext(PluginContext context) : base(context)
    {
        
    }

    private TEntity GetTarget()
    {
        if (!this.PluginExecutionContext.InputParameters.TryGetValue("Target", out object targetObject) || targetObject is null)
        {
            throw new ArgumentException("Unable to retrieve Target from context.");
        }

        return targetObject switch
        {
            EntityReference entityReference => new TEntity() { Id = entityReference.Id, LogicalName = entityReference.LogicalName },
            Entity entity => (TEntity)entity,
            _ => throw new ArgumentException("Unable to type Target.")
        };
    }

    private TEntity GetPreImage()
    {
        Entity? preImage = this.PluginExecutionContext.PreEntityImages
            .FirstOrDefault(x =>
                this.PreImageKey.Equals(x.Key, StringComparison.OrdinalIgnoreCase)).Value;

        return preImage is null
            ? new TEntity()
            : (TEntity)preImage;
    }

    private TEntity GetPostImage()
    {
        Entity? postImage = this.PluginExecutionContext.PostEntityImages
            .FirstOrDefault(x =>
                this.PostImageKey.Equals(x.Key, StringComparison.OrdinalIgnoreCase)).Value;

        return postImage is null
            ? new TEntity()
            : (TEntity)postImage;
    }
}