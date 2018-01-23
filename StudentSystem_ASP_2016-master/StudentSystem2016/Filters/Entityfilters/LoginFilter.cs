using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class LoginFilter
        : GenericFiler<SingIn>
    {
        public override Expression<Func<SingIn, bool>> BildFilter()
        {
            throw new NotImplementedException();
        }
    }
}