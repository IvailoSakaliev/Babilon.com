using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class ScolarshipServise:BaseServise<Scholarship>
    {
        public ScolarshipServise()
            :base()
        {

        }
        public ScolarshipServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
