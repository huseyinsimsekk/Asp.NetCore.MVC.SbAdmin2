using NLog;
using SbAdmin2.Core.Contracts;

namespace SbAdmin2.Service.Services
{
    public class LoggerService : ILoggerService
    {
        public ILogger _logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }
    }
}
