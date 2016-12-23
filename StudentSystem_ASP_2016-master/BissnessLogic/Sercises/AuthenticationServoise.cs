using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class AuthenticationServoise:BaseServise<SingIn>
    {
        public AuthenticationServoise()
            :base()
        {

        }
        public AuthenticationServoise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
