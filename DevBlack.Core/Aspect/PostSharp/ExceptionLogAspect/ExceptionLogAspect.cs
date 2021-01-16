using System;
using System.Reflection;
using DevBlack.Core.CrossCutingConcerns.Logging.Log4Net;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.ExceptionLogAspect
{[Serializable]
   public class ExceptionLogAspect:OnExceptionAspect
   {
       [NonSerialized]
       private LoggerService _service;

       private readonly Type _loggerType;

       public ExceptionLogAspect(Type loggerType)
       {
           _loggerType = loggerType;
       }

       public override void RuntimeInitialize(MethodBase method)
       {
           if (_loggerType!=null)
           {
               if (_loggerType.BaseType!=typeof(LoggerService))
               {
                   throw new Exception("Wrong Logger Type");
               }
           }

           _service = (LoggerService) Activator.CreateInstance(_loggerType);
           base.RuntimeInitialize(method);
       }

       public override void OnException(MethodExecutionArgs args)
       {
           if (_service!=null)
           {
              _service.Error(args.Exception);
           }
       }
   }
}
