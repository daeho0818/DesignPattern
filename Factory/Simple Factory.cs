using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class DbLogger { }
    class LoggerFactory
    {
        public DbLogger CreateDbLogger()
        {
            var db = new DbLogger();
            return db;
        }

        class Clent
        { }
        void HowToTest()
        {
            var factory = new LoggerFactory();
            var dbLogger = factory.CreateDbLogger();
        }
    }
}
