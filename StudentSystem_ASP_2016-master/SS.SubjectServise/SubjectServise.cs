using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.SubjectServise
{
    public class SubjectServise : BaseServise<Subject>
    {
        public SubjectServise()
            : base()
        {

        }
        public SubjectServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
