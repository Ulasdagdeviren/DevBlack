using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.DataAcsess.EntityFramework;
using DevBlack.Northwind.DataAcsess.Abstract;
using DevBlack.Northwind.Entity.ComplexTypes;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.DataAcsess.Concrete.EntityFramework
{
   public class EfUserDal:EfRepositoryBase<User,NorthwindContex>,IUserDal
    {
        public List<UserRoleItem> GetUsersRoles(User user)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                var result = from Ur in contex.UserRoles
                    join r in contex.Roles on Ur.UserId equals user.Id
                    where Ur.UserId == user.Id
                    select new UserRoleItem
                    {
                        RoleName = r.Name
                    };
                return result.ToList();
            }
        }
    }
}
