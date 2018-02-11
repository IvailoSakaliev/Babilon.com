using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class SingInServise
        :BaseServise<SingIn>
    {
        public SingInServise()
            :base()
        {

        }
        public SingInServise(UnitOfWork unit)
            :base(unit)
        {

        }

        
    }
}
