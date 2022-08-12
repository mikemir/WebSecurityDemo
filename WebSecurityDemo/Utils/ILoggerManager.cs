using System;

namespace WebSecurityDemo.Utils
{
    public interface ILoggerManager
    {
        void LogWarn(string message);

        void LogError(Exception exception);

        void LogInfo(string message);
    }
}
