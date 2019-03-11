using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CrossCutting
{
    public interface ILoggerService
    {
        void Action(string user,string url, string action, DateTime time);
        void Info(string message);
        void Error(string message);
        void Error(Exception ex, string message = null);
    }
}
