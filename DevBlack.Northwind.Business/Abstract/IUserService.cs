using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Entity.ComplexTypes;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.Business.Abstract
{
   public interface IUserService
   {
       User GetbyUserAndPassword(string userName, string password);
       List<UserRoleItem> GetUserRole(User user);
   }
}
