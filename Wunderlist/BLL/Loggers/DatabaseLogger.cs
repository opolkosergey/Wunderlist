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

        public void Debug(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() {Log = $"Debug : {s}"});
        }

        public void Trace(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() { Log = $"Trace : {s}" });
        }

        public void Info(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() { Log = $"Info : {s}" });
        }

        public void Warn(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() { Log = $"Warn : {s}" });
        }

        public void Fatal(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() { Log = $"Fatal : {s}" });
        }

        public void Error(string s)
        {
            _context.Set<LogEntity>().Add(new LogEntity() { Log = $"Error : {s}" });
        }
    }
}
