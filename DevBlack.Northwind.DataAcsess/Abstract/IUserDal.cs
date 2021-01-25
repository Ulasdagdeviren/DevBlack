using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.DataAcsess;
using DevBlack.Northwind.Entity.ComplexTypes;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.DataAcsess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
   {
       List<UserRoleItem> GetUsersRoles(User user);
   }
}
