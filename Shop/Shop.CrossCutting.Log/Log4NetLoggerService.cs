using System;
using log4net;

namespace Shop.CrossCutting.Log
{
    public class Log4NetLoggerService : ILoggerService
    {
        private readonly ILog _logger;

        public Log4NetLoggerService(ILog logger)
        {
            _logger = logger;
        }

        public void Error(string message) => _logger.Error(message);

        public void Error(Exception ex, string message = null) => _logger.Error(message,ex);

        public void Info(string message) => _logger.Info(message);
    }
}
