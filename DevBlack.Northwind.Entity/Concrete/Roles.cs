using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.Entities;

namespace DevBlack.Northwind.Entity.Concrete
{
   public class Roles:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
