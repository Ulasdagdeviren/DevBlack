using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Business.Abstract;
using DevBlack.Northwind.DataAcsess.Abstract;
using DevBlack.Northwind.Entity.ComplexTypes;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.Business.Concrete.Managers
{
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public User GetbyUserAndPassword(string userName, string password)
       {
           return _userDal.Get(x => x.UserName == userName & x.Password == password);
       }

        public List<UserRoleItem> GetUserRole(User user)
        {
            return _userDal.GetUsersRoles(user);
        }
    }
}
