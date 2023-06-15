namespace Domain.Logging;

/// <summary>
/// Represents a logger manager.
/// </summary>
public interface ILoggerManager
{
    /// <summary>
    /// Writes the diagnostic message at the Info level.
    /// </summary>
    /// <param name="message">Log message</param>
    void LogInfo(string message);

    /// <summary>
    /// Writes the diagnostic message at the Warn level.
    /// </summary>
    /// <param name="message">Log message</param>
    void LogWarn(string message);

    /// <summary>
    /// Writes the diagnostic message at the Debug level.
    /// </summary>
    /// <param name="message">Log message</param>
    void LogDebug(string message);

    /// <summary>
    /// Writes the diagnostic message at the Error level.
    /// </summary>
    /// <param name="message">Log message</param>
    void LogError(string message);
}