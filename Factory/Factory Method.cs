using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    interface ILog
    {
        void Write(string s);
    }
    class XmlLog : ILog
    {
        private string xmlFile;
        public XmlLog(string xmlFile)
        {
            this.xmlFile = xmlFile;
        }
        public void Write(string s)
        {

        }
    }

    class DbLog : ILog
    {
        private string connString;
        public DbLog(string connString)
        {
            this.connString = connString;
        }
        public void Write(string s)
        {

        }
    }
    abstract class LogFactory
    {
        protected abstract ILog GetLog();
        public void Log(string message)
        {
            var logger = GetLog();

            logger.Write($"{DateTime.Now} : {message}");
        }
    }

    class XmlLogFactory : LogFactory
    {
        protected override ILog GetLog()
        {
            string logfile = ConfigurationManager.AppSettings["xmlfile"];
            return new XmlLog(logfile);
        }
    }
    class DbLogFactory : LogFactory
    {
        protected override ILog GetLog()
        {
            string connString = ConfigurationManager.AppSettings["DBConn"];
            return new DbLog(connString);
        }
    }

    class Client
    {
        public void HowToTest()
        {
            LogFactory logger = new XmlLogFactory();
            logger.Log("Log something");
        }
    }
}