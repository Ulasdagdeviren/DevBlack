using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.Entities;

namespace DevBlack.Core.DataAcsess
{
   public interface IQeryableRepository<T> where T:class,IEntity,new()
    { 
        IQueryable<T> Table { get;}
    }
}
