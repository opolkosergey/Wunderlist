using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loggers
{
    public interface ILogger
    {
        void Log(Action<string> logMethod, string s);
    }
}
