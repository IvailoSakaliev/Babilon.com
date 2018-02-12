using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class SubjectFilter
        : GenericFiler<Subject>
    {
        public override Expression<Func<Subject, bool>> BildFilter()
        {
            Expression<Func<Subject, bool>> filter = null;
            return filter;
        }
    }
}