using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using StudentSystem2016.Atributes;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class ScollarShipFilter
        : GenericFiler<Scholarship>
    {
        public override Expression<Func<Scholarship, bool>> BildFilter()
        {
            Expression<Func<Scholarship, bool>> filter = null;
            return filter;
        }
    }
}