using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticFactoryMethod
{
    interface ILogger { }
    class DbLogger : ILogger { }
    class XmlLogger : ILogger { }
    class JsonLogger : ILogger { }
    class LoggerFactory
    {
        public static ILogger Create(string loggerType)
        {
            ILogger logger = null;

            switch (loggerType)
            {
                case "DB":
                    logger = new DbLogger();
                    break;
                case "XML":
                    logger = new XmlLogger();
                    break;
                case "JSON":
                    logger = new JsonLogger();
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return logger;
        }
    }

    class Client
    {
        void HowToTest()
        {
            ILogger logger = null;
            logger = LoggerFactory.Create("XML");
        }
    }
}
