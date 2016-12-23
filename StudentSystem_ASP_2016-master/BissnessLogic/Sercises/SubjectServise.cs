using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class SubjectServise:BaseServise<Subject>
    {
        public SubjectServise()
            :base()
        {

        }
        public SubjectServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
