using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions
{
    public interface ILogService
    {
        void LogError(string message);
        void LogError(Exception ex);
    }
}
