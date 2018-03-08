using DataAcsess.Models;
using DataAcsess.Repository;
using DataAcsess.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BissnessLogic.Sercises
{
    public class StudentServise
        :BaseServise<Student>
    {
        public StudentServise()
            :base()
        {
            
        }
        
        public StudentServise(UnitOfWork unit)
            :base(unit)
        {

        }

        public Student GetByloginID(int id)
        {
            Student student = new Student();
            List<Student> list = repo.GetAll((u) => u.Login == id).ToList();
            student = list.Count > 0 ? list[0] : null;
            return student;
        }
    }
}
