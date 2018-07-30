using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecialtySubjectServise
{
    public class SpecialtySubjectServise
        :BaseServise<SpecialtySubject>
    {
        public SpecialtySubjectServise()
            :base()
        {

        }

        public SpecialtySubjectServise(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
