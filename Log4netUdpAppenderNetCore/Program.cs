using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Log4netUpdAppenderNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var test = new TestClass();
            test.Run();
        }
    }
}
