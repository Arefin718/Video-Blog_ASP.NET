using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeService.Interface;

namespace YoutubeService.Class
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        Repository<TEntity> repo = new Repository<TEntity>();
        //public int Delete(TEntity entity)
        //{
        //    return this.repo.Delete(entity);
        //}
        public int Delete(int  id)
        {
            return this.repo.Delete(id);
        }

        public TEntity Get(int id)
        {
            return this.repo.Get(id);
        }

        public List<TEntity> GetAll()
        {
            return this.repo.GetAll();
        }

        public int Insert(TEntity entity)
        {
            return this.repo.Insert(entity);
        }

        public int Update(TEntity entity)
        {
            return this.repo.Update(entity);
        }
    }
}
