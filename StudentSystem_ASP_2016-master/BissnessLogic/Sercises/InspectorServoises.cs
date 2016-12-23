using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class InspectorServoises : BaseServise<Inspector>
    {
        public InspectorServoises()
            :base()
        {

        }
        public InspectorServoises(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
