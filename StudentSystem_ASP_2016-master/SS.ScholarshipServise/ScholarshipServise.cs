using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.ScholarshipServise
{
    public class ScholarshipServise : BaseServise<Scholarship>
    {
        public ScholarshipServise()
            : base()
        {

        }
        public ScholarshipServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
