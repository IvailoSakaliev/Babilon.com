using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class LectureServise: BaseServise<Lecture>
    {
        public LectureServise()
            :base()
        {

        }
        public LectureServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
