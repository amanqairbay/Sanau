using Domain.Logging;
using NLog;

namespace Persistence.Logging;

public class LoggerManager : ILoggerManager
{
    #region fields
	private static ILogger logger = LogManager.GetCurrentClassLogger();

    #endregion fields

    #region ctor
	public LoggerManager() { }

    #endregion ctor

    #region methods

    /// <summary>
    /// Writes the diagnostic message at the Debug level.
    /// </summary>
    /// <param name="message">Log message</param>
	public void LogDebug(string message) => logger.Debug(message);

    /// <summary>
    /// Writes the diagnostic message at the Error level.
    /// </summary>
    /// <param name="message">Log message</param>
	public void LogError(string message) => logger.Error(message);

    /// <summary>
    /// Writes the diagnostic message at the Info level.
    /// </summary>
    /// <param name="message">Log message</param>
	public void LogInfo(string message) => logger.Info(message);

    /// <summary>
    /// Writes the diagnostic message at the Warn level.
    /// </summary>
    /// <param name="message">Log message</param>
	public void LogWarn(string message) => logger.Warn(message);

    #endregion methods
}