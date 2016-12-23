using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class ScholarshipServise:BaseServise<Scholarship>
    {
        public ScholarshipServise()
            :base()
        {

        }
        public ScholarshipServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
