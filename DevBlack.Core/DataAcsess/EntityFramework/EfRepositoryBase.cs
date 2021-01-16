using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.Entities;

namespace DevBlack.Core.DataAcsess.EntityFramework
{
   public class EfRepositoryBase<Tentity,TContex>:IEntityRepository<Tentity> where Tentity:class,IEntity,new()
   where TContex:DbContext,new()
    {
        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (TContex contex=new TContex())
            {
                return filter == null ? contex.Set<Tentity>().ToList() : contex.Set<Tentity>().Where(filter).ToList();
            }
          
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (TContex contex=new TContex())
            {
                return contex.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public Tentity Add(Tentity entity)
        {
            using (TContex contex=new TContex())
            {
                var add = contex.Entry(entity);
                add.State = EntityState.Added;
                contex.SaveChanges();
                return entity;
            }
        }

        public Tentity Update(Tentity entity)
        {
            using (TContex contex=new TContex())
            {
                var update = contex.Entry(entity);
                update.State = EntityState.Modified;
                contex.SaveChanges();
                return entity;
            }
        }

        public void Delete(Tentity entity)
        {
            using (TContex contex=new TContex())
            {
                var delete = contex.Entry(entity);
                delete.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }
    }
}
