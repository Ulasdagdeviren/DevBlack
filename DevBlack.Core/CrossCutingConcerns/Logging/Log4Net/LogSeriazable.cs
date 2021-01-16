using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace DevBlack.Core.CrossCutingConcerns.Logging.Log4Net
{[Serializable]
  public class LogSeriazable
  {
      private LoggingEvent _event;

      public LogSeriazable(LoggingEvent @event)
      {
          _event = @event;
      }

      public string UserName => _event.UserName;
      public object Message => _event.MessageObject;

  }
}
