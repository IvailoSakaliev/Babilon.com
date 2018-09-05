using System.Data.Entity;
using DataAcsess.Models;
using System.Data.Entity.Infrastructure;

namespace DataAcsess
{
    public interface IStudentDBContext
    {
        DbSet<Facultet> Facultets { get; set; }
        DbSet<Lecture> Lecturs { get; set; }
        DbSet<Subject> Predmets { get; set; }
        DbSet<Scholarship> Scholarships { get; set; }
        DbSet<SingIn> SingIns { get; set; }
        DbSet<Specialty> Specialties { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Evaluation> Evaluations { get; set; }

        void SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}