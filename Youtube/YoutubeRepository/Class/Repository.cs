using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;
using System.Data.Entity.Migrations;

namespace YoutubeRepository.Class
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity
    {
        DataContext context = new DataContext();

        //public int Delete(TEntity entity)
        //{
        //    this.context.Set<TEntity>().Remove(entity);
        //    return context.SaveChanges();
        //}

        public int Delete(int id)
        {
            TEntity en = context.Set<TEntity>().Find(id);
            this.context.Set<TEntity>().Remove(en);
            return context.SaveChanges();
        }


        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().AsNoTracking().SingleOrDefault(u=>u.Id==id);
        }

        public List<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public int Insert(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
     
            // this.context.Entry<TEntity>(entity).State=EntityState.Modified;
            context.Set<TEntity>().AddOrUpdate(entity);
            return context.SaveChanges();
        }
    }
}
