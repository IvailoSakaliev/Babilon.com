using DataAcsess.Models;
using DataAcsess.Repository;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
