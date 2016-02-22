using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;

namespace BLL.Loggers
{
    public class DatabaseLogger : ILogger
    {
        private WunderlistContext _context; 
        public void Log(Action<string> logMethod, string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() {Log = $"{logMethod.Method.Name} : {s}"});
        }
    }
}
