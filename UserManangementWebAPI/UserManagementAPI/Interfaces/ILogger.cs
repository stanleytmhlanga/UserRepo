using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Model;

namespace UserManagementAPI.Interfaces
{
    public interface ILogger
    {
        void Trace(string message);
        void Debug(string message);
        void Info(string message);

        void Warn(string message);
        void Warn(Exception error);
        void Warn(string message, Exception error);

        void Error(string message);
        void Error(Exception error);
        void Error(string message, Exception error);
        void Error(LogFields fields, Exception error);
        void Fatal(string message);
        void Fatal(Exception error);

        void Fatal(string message, Exception error);
        [Obsolete("Please use Trace(LogFields fields, string message ")]
        void Trace(string component, string message);
        [Obsolete("Please use Debug(LogFields fields, string message ")]
        void Debug(string component, string message);
        [Obsolete("Please use Info(LogFields fields, string message ")]
        void Info(string component, string message);

        void Trace(LogFields fields, string message);
        void Debug(LogFields fields, string message);
        void Info(LogFields fields, string message);

        void Warn(string component, string message);
        void Warn(string component, string message, Exception error);
        void Warn(LogFields fields, string message, Exception error);
        [Obsolete("Please use Error(LogFields fields, string message ")]
        void Error(string component, string message);
        void Error(LogFields fields, string message);
        [Obsolete("Please use Error(LogFields fields, string message, Exception error ")]
        void Error(string component, string message, Exception error);
        void Error(LogFields fields, string message, Exception error);
        [Obsolete("Please use Fatal(LogFields fields, string message, ")]
        void Fatal(string component, string message);
        void Fatal(string component, string message, Exception error);
        void Fatal(LogFields fields, string message);
        void Fatal(LogFields fields, string message, Exception error);
    }
}
