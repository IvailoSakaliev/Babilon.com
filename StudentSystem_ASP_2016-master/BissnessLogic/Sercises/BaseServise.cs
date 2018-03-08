using DataAcsess.Models;
using DataAcsess.Repository;
using DataAcsess.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class BaseServise<TEntity> where TEntity: BaseModel, new()
    {
        public GenericRepository<TEntity> repo { get; set; }
        public UnitOfWork unit;

        public BaseServise()
        {
            this.repo = new GenericRepository<TEntity>(new UnitOfWork());
            this.unit = new UnitOfWork();
        }

        public BaseServise(UnitOfWork unit)
        {
            this.repo = new GenericRepository<TEntity>(unit);
            this.unit = unit;
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null , int page = 1, int pageSize = 1)
        {
            return this.repo.GetAll(filter, page,pageSize);
        }

        public TEntity GetByID(int? id)
        {
            return this.repo.GetByID(id);
        }


        public void Save(TEntity entity)
        {
            try
            {
                this.repo.Save(entity);
                this.unit.Commit();
            }
            catch(Exception)
            {
                this.unit.Rowback();
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                this.repo.Delete(entity);
                this.unit.Commit();
            }
            catch (Exception)
            {
                this.unit.Rowback();
            }
        }
        public void DeleteById(int id)
        {
            try
            {
                this.repo.DeleteById(id);
                this.unit.Commit();
            }
            catch (Exception)
            {
                this.unit.Rowback();
            }
        }

    }
}
