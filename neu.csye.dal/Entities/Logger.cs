using neu.csye.dal.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Entities
{
    public class Logger : ILog
    {
        private Logger() { }
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());
        public static Logger GetInstance() => instance.Value;
        public void LogException(string message, DateTime dateTime)
        {

        }
    }
}
