using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SingInServise
{
    public class SingInServise
       : BaseServise<SingIn>
    {
        public SingInServise()
            : base()
        {

        }
        public SingInServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
