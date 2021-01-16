using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.CrossCutingConcerns.Logging;
using DevBlack.Core.CrossCutingConcerns.Logging.Log4Net;
using FluentValidation.Results;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.LogAspect
{[Serializable]
    public class LogAspect :OnMethodBoundaryAspect
    {
        private Type _logType;
        private LoggerService _loggerService;

        public LogAspect(Type logType)
        {
            _logType = logType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_logType.BaseType!=typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }

            _loggerService = (LoggerService) Activator.CreateInstance(_logType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {
               
            }
            

        }
    }
}
