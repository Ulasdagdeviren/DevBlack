using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevBlack.Core.CrossCutingConcerns.Security.Web
{
   public class SecurityUtilities
    {
        public İdentity FormsAuthTickedIdentity(FormsAuthenticationTicket ticked)
        {
            var ıdentity=new İdentity
            {
                AuthenticationType = SetAuthentication(),
                Email = SetEmail(ticked),
                FirstName = SetFirstName(ticked),
                Id = SetId(ticked),
                IsAuthenticated = SetAuthenticated(),
                LastName = SetLastName(ticked),
                Name = SetName(ticked),
                Roles =SetRoles(ticked)
            };
            return ıdentity;
        }

        private string[] SetRoles(FormsAuthenticationTicket ticked)
        {
            string[] data = ticked.UserData.Split('|');
            string[] roles = data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetName(FormsAuthenticationTicket ticked)
        {
            return ticked.Name;
        }

        private string SetLastName(FormsAuthenticationTicket ticked)
        {
            string[] data = ticked.UserData.Split('|');
            return data[3];
        }

        private bool SetAuthenticated()
        {
            return true;
        }

        private Guid SetId(FormsAuthenticationTicket ticked)
        {
            string[] data = ticked.UserData.Split('|');
            return new Guid(data[4]);
        }

        private string SetFirstName(FormsAuthenticationTicket ticked)
        {
            string[] data = ticked.UserData.Split('|');
            return data[2];
        }

        private string SetEmail(FormsAuthenticationTicket ticked)
        {
            string[] data = ticked.UserData.Split('|');
            return data[1];
        }

        private string SetAuthentication()
        {
            return "Forms";
        }
    }
}
