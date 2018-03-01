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
            :base("StudentSystemDBase2016test")
        {
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Scholarship> Scholarships { get; set; }
        public IDbSet<Specialty> Specialties { get; set; }
        public IDbSet<Subject> Predmets { get; set; }
        public IDbSet<SingIn> SingIns { get; set; }
        public IDbSet<Facultet> Facultets { get; set; }
        public IDbSet<Lecture> Lecturs { get; set; }

        

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
