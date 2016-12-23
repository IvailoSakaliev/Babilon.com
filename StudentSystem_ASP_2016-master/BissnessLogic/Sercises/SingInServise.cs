using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class LectorServise:BaseServise<SingIn>
    {
        public LectorServise()
            :base()
        {

        }
        public LectorServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
