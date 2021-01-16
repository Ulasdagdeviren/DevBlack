using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.Entities;

namespace DevBlack.Core.DataAcsess.EntityFramework
{
   public class EfQeryableRepository<T> :IQeryableRepository<T> where T:class,IEntity,new()
   {
       private DbContext _context;
       private IDbSet<T> _dbSet;

       public EfQeryableRepository(DbContext context)
       {
           _context = context;
       }

       public IQueryable<T> Table => this.Entities;
      protected virtual IDbSet<T> Entities => _dbSet ?? _context.Set<T>();
   }
}
