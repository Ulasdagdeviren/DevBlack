using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DevBlack.Core.CrossCutingConcerns.Logging.Log4Net
{[Serializable]
   public class LoggerService
   {
       private ILog _log;

       public LoggerService(ILog log)
       {
           _log = log;
       }

       public bool IsDebugEnabled => _log.IsDebugEnabled;
       public bool IsInfoEnabled => _log.IsInfoEnabled;
       public bool IsFatalEnabled => _log.IsFatalEnabled;
       public bool IsErrorEnabled => _log.IsFatalEnabled;
       public bool IsWarnEnabled => _log.IsWarnEnabled;

       public void Info(object message)
       {
           if (IsInfoEnabled)
           {
               _log.Info(message);
           }
       }

       public void Debug(object message)
       {
           if (IsDebugEnabled)
           {
               _log.Debug(message);
           }
       }

       public void Fatal(object message)
       {
           if (IsFatalEnabled)
           {
               _log.Fatal(message);
           }
            
       }

       public void Error(object message)
       {
           if (IsErrorEnabled)
           {
               _log.Error(message);
           }
        
       }

       public void Warn(object message)
       {
           if (IsWarnEnabled)
           {
               _log.Warn(message);
           }
       }
   }
}
