using DataAcsess.Models;
using DataAcsess.UnitOfWork;

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
