using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loggers
{
    public interface ILogger
    {
        void Debug(string s);
        void Trace(string s);
        void Info(string s);
        void Warn(string s);
        void Fatal(string s);
        void Error(string s);
    }
}
