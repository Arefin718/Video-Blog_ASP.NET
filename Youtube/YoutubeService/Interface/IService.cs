using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IService<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        int Delete(int  id);
        //int Delete(TEntity entity);
        int Update(TEntity entity);
        int Insert(TEntity entity);
    }
}
