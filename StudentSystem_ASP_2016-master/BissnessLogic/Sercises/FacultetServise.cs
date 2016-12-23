using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class FacultetServise: BaseServise<Facultet>
    {
        public FacultetServise()
            :base()
        {

        }
        public FacultetServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
