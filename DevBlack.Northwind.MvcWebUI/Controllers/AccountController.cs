using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBlack.Core.CrossCutingConcerns.Security.Web;
using DevBlack.Northwind.Business.Abstract;

namespace DevBlack.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }
        // GET: User

        public string Login(string userName, string password)
        {
            var user = _service.GetbyUserAndPassword(userName, password);
            if (user!=null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(), userName, user.Email, DateTime.Now.AddDays(15),
                    _service.GetUserRole(user).Select(u => u.RoleName).ToArray(),
                    false, user.FirstName, user.LastName);
                return "User is Authenticated";
            }

            return "User is Not Authenticated";


        }
    }
}