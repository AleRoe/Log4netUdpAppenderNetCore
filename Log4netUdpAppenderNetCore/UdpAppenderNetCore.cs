using System.Text;

namespace log4net.Appender
{
    public class UdpAppenderNetCore : UdpAppender
    {

        public UdpAppenderNetCore() : base()
        {
#if NETCOREAPP3_0
            //By default, UdpAppender uses Unicode encoding when running under netcoreapp,
            //resulting in UDP-packets which cannot be properly interpreted.
            //To resolve, we set the proper encoding (UTF8)
            this.Encoding = Encoding.Default;
#endif
        }
    }
}
