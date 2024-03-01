namespace PluginsBase.Enums;

/// <summary>
/// Stage in the event execution pipeline at which the plugin should be executed.
/// </summary>
public enum PluginStage
{
    /// <summary>
    /// Occurs before any business logic or database transactions.
    /// Mainly used for validation checks prior to the main operation.
    /// It occurs even if the operation itself is not executed (e.g., due to security constraints).
    /// </summary>
    PreValidation = 10,

    /// <summary>
    /// Executes before the main operation logic begins but after the pre-validation stage.
    /// Changes made in this stage are included in the transaction.
    /// Commonly used for data manipulation or to prevent the operation from executing.
    /// </summary>
    PreOperation = 20,

    /// <summary>
    /// Occurs after the main operation.
    /// Changes made in this stage are part of the transaction but occur after the main database commit.
    /// Useful for operations that need to occur after the main operation is completed, like triggering additional processes or integrations.
    /// </summary>
    PostOperation = 40
}