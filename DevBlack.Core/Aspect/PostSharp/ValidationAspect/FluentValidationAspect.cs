using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.CrossCutingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.ValidationAspect
{[Serializable]
   public class FluentValidationAspect:OnMethodBoundaryAspect
   {
       private Type _validatorType;

       public FluentValidationAspect(Type validatorType)
       {
           _validatorType = validatorType;
       }

       public override void OnEntry(MethodExecutionArgs args)
       {
           var Validator = (IValidator) Activator.CreateInstance(_validatorType);
           var EntityType = _validatorType.BaseType.GetGenericArguments()[0];
           var entities = args.Arguments.Where(x => x.GetType() == EntityType);
           foreach (var entity in entities)
           {
               ValidatorTool.FluentValidate(Validator,entity);
           }

       }
   }
}
