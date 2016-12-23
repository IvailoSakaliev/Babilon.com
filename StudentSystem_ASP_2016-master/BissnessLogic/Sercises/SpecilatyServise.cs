using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class SpecilatyServise:BaseServise<Specialty>
    {
        public SpecilatyServise()
            :base()
        {

        }
        public SpecilatyServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
