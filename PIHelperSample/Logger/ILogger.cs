using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHelperSample.Logger
{
    public interface ILogger
    {
        void LogDebug(string message);
        void LogError(string message);
        void LogError(string message, Exception exception);
    }
}
