using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.AuthorizationAspect
{[Serializable]
   public class SecuredOperation: OnMethodBoundaryAspect // Authorization Aspect = yetkilendirme unsuru
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorrized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorrized = true;
                }
            }

            if (isAuthorrized==false)
            {
                throw new SecurityException("You are not Authorized");
            }
        }
    }
}
