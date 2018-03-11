using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.ScolarshipServise
{
    public class ScolarshipServise
         : BaseServise<Scholarship>
    {
        public ScolarshipServise()
            : base()
        {

        }
        public ScolarshipServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }

}
