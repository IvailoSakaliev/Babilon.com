using System.Data.Entity;
using DataAcsess.Models;
using System.Data.Entity.Infrastructure;

namespace DataAcsess
{
    public interface IStudentDBContext
    {
        IDbSet<Facultet> Facultets { get; set; }
        IDbSet<Lecture> Lecturs { get; set; }
        IDbSet<Subject> Predmets { get; set; }
        IDbSet<Scholarship> Scholarships { get; set; }
        IDbSet<SingIn> SingIns { get; set; }
        IDbSet<Specialty> Specialties { get; set; }
        IDbSet<Student> Students { get; set; }
        void SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}