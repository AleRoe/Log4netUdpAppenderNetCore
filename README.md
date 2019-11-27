# Log4netUdpAppenderNetCore
##Making log4net.Appender.UdpAppender work under netcoreapp3.0

When using log4net.logging.UdpAppender under netcoreapp3.0, logging messages are not properly emitted due to the fact that log4net uses Unicode as the default encoding for netcoreapp3.0.

This results in UDP packets which cannot be properly interpreted:
![alt text](Wireshark1.png)

A simple workaround is to derive from UpdAppender and conditionally modify the encoding in the constructor and then referencing the new appender in your log4netconfig.

````
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
````

With this change, the logging messages are sent in the proper format and can be interpreted by common logviewers (in my case using Log4View).

![alt text](Wireshark2.png)

Hope this helps!
