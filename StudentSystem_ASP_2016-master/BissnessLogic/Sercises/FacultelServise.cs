using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class FacultelServise:BaseServise<Facultet>
    {
        public FacultelServise()
            :base()
        {

        }
        public FacultelServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
