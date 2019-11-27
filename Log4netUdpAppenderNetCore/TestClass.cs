using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.PlatformAbstractions;

namespace Log4netUpdAppenderNetCore
{
    public class TestClass
    {
        private readonly ILog logger;

        public TestClass()
        {
            logger = LogManager.GetLogger(this.GetType());
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                logger.Info($"Logging test message {i} ({PlatformServices.Default.Application.RuntimeFramework})");
                Task.Delay(200).Wait();
            }
        }
    }
}
