namespace PluginsBase.Enums;

/// <summary>
/// Most common plugin messages that are used, when the plugin should trigger.
/// </summary>
public enum PluginMessage
{
    /// <summary>
    /// Triggered when a new record is created.
    /// </summary>
    Create,

    /// <summary>
    /// Triggered when an existing record is modified.
    /// </summary>
    Update,

    /// <summary>
    /// Triggered when a record is deleted.
    /// </summary>
    Delete,

    /// <summary>
    /// Triggered when a record is retrieved.
    /// </summary>
    Retrieve,

    /// <summary>
    /// Triggered when multiple records are retrieved.
    /// </summary>
    RetrieveMultiple,

    /// <summary>
    /// Triggered during the merging of two records.
    /// </summary>
    Merge,

    /// <summary>
    /// Triggered when a relationship is created between two records.
    /// </summary>
    Associate,

    /// <summary>
    /// Triggered when a relationship between two records is removed.
    /// </summary>
    Disassociate,

    CalculatePrice,

    Lose,

    Win,

    QualifyLead
}