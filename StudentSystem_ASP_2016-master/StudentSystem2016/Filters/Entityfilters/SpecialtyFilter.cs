using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class SpecialtyFilter
        : GenericFiler<Specialty>
    {
        public override Expression<Func<Specialty, bool>> BildFilter()
        {
            Expression<Func<Specialty, bool>> filter = null;
            return filter;
        }
    }
}