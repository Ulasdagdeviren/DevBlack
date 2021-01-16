using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DevBlack.Core.CrossCutingConcerns.Validation.FluentValidation
{
   public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator,object entity)
        {
            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
