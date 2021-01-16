using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DevBlack.Core.CrossCutingConcerns.Security
{
   public class İdentity:IIdentity // identity = kimlik   
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; } //  AuthenticationType=kimlik doğrulama türü
        public bool IsAuthenticated { get; set; } //  IsAuthenticated = doğrulanmış
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles  { get; set; }



    }
}
