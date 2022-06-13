using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Functions.Interfaces
{
    public interface ILog
    {
        void LogException(string message, DateTime dateTime);
    }
}
