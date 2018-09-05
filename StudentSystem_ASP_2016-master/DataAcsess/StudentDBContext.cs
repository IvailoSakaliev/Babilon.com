using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess
{
    public class StudentDBContext : DbContext, IStudentDBContext
    {
        public StudentDBContext()
            :base("StudentSystem-DB")
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Subject> Predmets { get; set; }
        public DbSet<SingIn> SingIns { get; set; }
        public DbSet<Facultet> Facultets { get; set; }
        public DbSet<Lecture> Lecturs { get; set; }
        public DbSet<SpecialtySubject> SubjectSpecialty { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

       
    }
}
