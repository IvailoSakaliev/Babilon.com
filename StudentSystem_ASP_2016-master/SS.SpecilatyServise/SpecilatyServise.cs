using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecilatyServise
{
    public class SpecilatyServise : BaseServise<Specialty>
    {
        public SpecilatyServise()
            : base()
        {

        }
        public SpecilatyServise(UnitOfWork unit)
            : base(unit)
        {

        }
         
    }
}
