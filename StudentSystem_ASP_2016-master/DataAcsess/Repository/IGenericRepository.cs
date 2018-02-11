using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null ,int page = 1, int pageSize = 1);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetByID(int? id);
        void Delete(TEntity entity);
        void Save(TEntity entity);
        void DeleteById(int id);
    }
}
