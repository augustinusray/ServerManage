using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;

namespace ServerManage.Logger
{
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers =
            new ConcurrentDictionary<string, Log4NetLogger>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log4NetConfigFile"></param>
        public Log4NetProvider(string log4NetConfigFile)
        {
            _log4NetConfigFile = log4NetConfigFile;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Dispose()
        {
            _loggers.Clear();
        }
        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(filename));
            return log4NetConfig["log4net"];
        }
    }
}
