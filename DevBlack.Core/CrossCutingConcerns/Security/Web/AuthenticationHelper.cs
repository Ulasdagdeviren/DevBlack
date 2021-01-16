using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DevBlack.Core.CrossCutingConcerns.Security.Web
{                                   // CreateAuthCookie = kimlik doğrulama çerezi oluşturun CreateAuthTags= Kimlik Doğrulama Etiketleri Oluşturun
    public class AuthenticationHelper //AuthenticationHelper = kimlik doğrulama yardımcısı
    {
        public static void CreateAuthCookie(Guid id,string userName,string email,DateTime expration,string[] roles,
            bool rememberMe,string firstName,string lastName)
        {
            var authTicked = new FormsAuthenticationTicket(1, userName, DateTime.Now, expration, rememberMe,
                CreateAuthTags(email, roles, firstName, lastName, id));
            string enTicked = FormsAuthentication.Encrypt(authTicked);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicked));

        }

        private static string CreateAuthTags(string email, string[] roles, string firsName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder(); // verilen ifadeliri append ile birleştir + ifadesi ile aynı
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i<roles.Length-1)
                {
                    stringBuilder.Append(",");
                }
                
            }

            stringBuilder.Append("|");
            stringBuilder.Append(firsName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);

            return stringBuilder.ToString();
        }
    }
}
