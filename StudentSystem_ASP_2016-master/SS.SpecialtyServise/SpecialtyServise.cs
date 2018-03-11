using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecialtyServise
{
    public class SpecialtyServise : BaseServise<Specialty>
    {
        public SpecialtyServise()
            : base()
        {

        }
        public SpecialtyServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
