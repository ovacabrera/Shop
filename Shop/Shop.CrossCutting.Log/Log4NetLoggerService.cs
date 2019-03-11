using System;
using log4net;
using log4net.Repository.Hierarchy;

namespace Shop.CrossCutting.Log
{
    public class Log4NetLoggerService : ILoggerService
    {
        private readonly ILog _logger;

        public Log4NetLoggerService()
        {            
            _logger = log4net.LogManager.GetLogger(typeof(Logger));
            if (!_logger.Logger.Repository.Configured)
            {
                log4net.Config.XmlConfigurator.Configure();
            }
        }

        public void Error(string message) => _logger.Error(message);

        public void Error(Exception ex, string message = null) => _logger.Error(message,ex);

        public void Action(string user, string url, string action, DateTime time)
        {
            string newLine = "\n";
            _logger.Info(newLine + "User:"+user + newLine + "URL:" + url + newLine + "Action:"+action+newLine+"Time:"+time);
        }

        public void Info(string message) => _logger.Info(message);
    }
}
