using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Core.Log
{


    public class LogSystem
    {

        #region Instance
        private static LogSystem _instance;
        private static object lockObj = new object();
        public static LogSystem Logger
        {
            get
            {
                if (_instance == null)
                    lock (lockObj)
                        if (_instance == null)
                            _instance = new LogSystem();
                return _instance;
            }
        }
        #endregion
        #region Private Variables
        private string logFilePath;
        private readonly ILog Log;
        private ILoggerRepository logRepository;
        private string moduleName;
        #endregion
        #region Construct
        public LogSystem()
        {
            var asm = Assembly.GetCallingAssembly();
            logRepository = LogManager.GetRepository(asm);
            moduleName = asm.GetName().Name.Replace(".", "_");
            Log = LogManager.GetLogger(asm.GetType());
            configure();
        }
        #endregion
        #region Private Methods
        private void configure()
        {
            var dirPath = Path.Combine(Environment.CurrentDirectory, "logs");
            Directory.CreateDirectory(dirPath);

            var dt = DateTime.Now;

            var yearPath = Path.Combine(dirPath, dt.Year.ToString());
            Directory.CreateDirectory(yearPath);

            var monthPath = Path.Combine(yearPath, dt.Month.ToString());
            Directory.CreateDirectory(monthPath);

            var logFileName = string.Format("{0}-{1}-{2}-{3}.log", moduleName, dt.Year, dt.Month, dt.Day);
            logFilePath = Path.Combine(monthPath, logFileName);

            var fileAppender = getFileAppender(logFilePath);
            ((Hierarchy)logRepository).Root.Level = Level.All;
            BasicConfigurator.Configure(logRepository, fileAppender);


        }
        private IAppender getFileAppender(string logFile)
        {
            var layout = new PatternLayout("[%thread] [%date] [%level] [%message] %newline %exception %newline");
            layout.ActivateOptions();
            var appender = new RollingFileAppender
            {
                AppendToFile = true,
                File = logFile,
                Layout = layout,
                MaxSizeRollBackups = 100,
                MaximumFileSize = "5MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                LockingModel = new LogLockMechanism()
            };
            appender.ActivateOptions();
            return appender;
        }
        #endregion
        #region Public Methods
        public void Info(object message, Exception ex = null)
        {
            Log.Info(message, ex);
        }
        public void Debug(object message, Exception ex = null)
        {
            Log.Debug(message, ex);
        }
        public void Warning(object message, Exception ex = null)
        {
            Log.Warn(message, ex);
        }
        public void Error(object message, Exception ex = null)
        {
            Log.Error(message, ex);
        }
        public void Fatal(object message, Exception ex = null)
        {
            Log.Fatal(message, ex);
        }
        #endregion
        #region Internal Class
        public class LogLockMechanism : FileAppender.MinimalLock
        {
            public override void ReleaseLock()
            {
                base.ReleaseLock();

                var logFile = new FileInfo(CurrentAppender.File);
                if (logFile.Exists && logFile.Length <= 0)
                {
                    logFile.Delete();
                }
            }

        }
        #endregion
    }
}
