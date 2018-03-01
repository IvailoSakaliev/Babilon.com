using DataAcsess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Repository
{
    public class GenericRepository<Tentity> 
        :IGenericRepository<Tentity> where Tentity
            :BaseModel,new()
    {
        private IStudentDBContext context { get; set; }
        protected IDbSet<Tentity> set { get; set; }
        private UnitOfWork.UnitOfWork unit { get; set; }

        public GenericRepository()
        {
            this.context = new StudentDBContext();
            this.set = context.Set<Tentity>();
        }
        public GenericRepository(UnitOfWork.UnitOfWork unit)
        {
            this.unit = unit;
            this.context = unit.context;
            this.set = context.Set<Tentity>();
        }

        public IList<Tentity> GetAll(Expression<Func<Tentity, bool>> filter, int page = 1 , int pageSize = 1)
        {
            IQueryable<Tentity> query = this.set;
            if (filter != null)
            {
                return this.set.Where(filter)
                    .OrderBy(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                return this.set.OrderBy(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            
        }
        public IList<Tentity> GetAll()
        {
            return this.set.ToList();
        }
       
        public IList<Tentity>GetAll(Expression<Func<Tentity, bool>> filter)
        {
            if (filter != null)
            {
                return this.set.Where(filter).ToList();
            }
            else
            {
                return this.set.ToList();
            }
        }

        public Tentity GetByID(int? id)
        {
            return this.set.Find(id);
        }

        public void Delete(Tentity entity)
        {
            set.Remove(entity);
            Updatestation(entity, EntityState.Deleted);
        }

        private void Add(Tentity entity)
        {
            set.Add(entity);
            Updatestation(entity, EntityState.Added);
        }

        private void Update(Tentity entity)
        {
            Updatestation(entity, EntityState.Modified);
        }

        public void Save(Tentity entity)
        {
            if (entity.ID == 0)
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }

        }

        private void Updatestation(Tentity entity, EntityState state)
        {
           var dbentry = this.context.Entry(entity);
            dbentry.State = state;
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Tentity entity = new Tentity();
            entity = GetByID(id);
            Delete(entity);
        }
    }
}
