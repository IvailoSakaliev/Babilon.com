using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcsess.Repository
{
    public class GenericRepository<Tentity> 
        :IGenericRepository<Tentity> where Tentity
            :Parent,new()
    {
        private IStudentDBContext _context { get; set; }
        protected IDbSet<Tentity> _set { get; set; }
        private UnitOfWork.UnitOfWork _unit { get; set; }

        public GenericRepository()
        {
            _context = new StudentDBContext();
            _set = _context.Set<Tentity>();
        }
        public GenericRepository(UnitOfWork.UnitOfWork unit)
        {
            _unit = unit;
            _context = unit.context;
            _set = _context.Set<Tentity>();
        }

        public IList<Tentity> GetAll(Expression<Func<Tentity, bool>> filter, int page = 1 , int pageSize = 10)
        {
            IQueryable<Tentity> query = _set;
            if (filter != null)
            {
                return _set.Where(filter)
                    .OrderBy(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                return _set.OrderBy(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            
        }
        public IList<Tentity> GetAll()
        {
            return _set.ToList();
        }
       
        public IList<Tentity>GetAll(Expression<Func<Tentity, bool>> filter)
        {
            if (filter != null)
            {
                return _set.Where(filter).ToList();
            }
            else
            {
                return _set.ToList();
            }
        }

        public Tentity GetByID(int? id)
        {
            return _set.Find(id);
        }

        public void Delete(Tentity entity)
        {
            _set.Remove(entity);
            Updatestation(entity, EntityState.Deleted);
        }

        private void Add(Tentity entity)
        {
            _set.Add(entity);
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
           var dbentry = _context.Entry(entity);
            dbentry.State = state;
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Tentity entity = new Tentity();
            entity = GetByID(id);
            Delete(entity);
            _context.SaveChanges();
        }
    }
}
