using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem2016
{
    public class StudentDBContext : DbContext, IStudentDBContext
    {
        public StudentDBContext()
            :base("vavilonci_")
        {
        }
        
        public DbSet<BaseType> BaseTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Hash> Hashes { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeSubject> TypeSubjects { get; set; }
        public DbSet<User> Users { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

       
    }
}
