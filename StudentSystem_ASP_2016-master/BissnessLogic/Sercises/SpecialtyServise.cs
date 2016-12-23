using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class SpecialtyServise:BaseServise<Specialty>
    {
        public SpecialtyServise()
            :base()
        {

        }
        public SpecialtyServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
