using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentSystem2016.Filters;
using System.Linq.Expressions;

namespace StudentSystem2016.Filters
{
    public class AuturizationFilter
        : GenericFiler<SingIn>
    {

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override Expression<Func<SingIn, bool>> BildFilter()
        {
            Expression<Func<SingIn, bool>> filter =
                m => (string.IsNullOrEmpty(this.Username) || m.UserName.Contains(this.Username.Trim()))
                && (string.IsNullOrEmpty(this.FirstName) || m.Password.Contains(this.FirstName.Trim()));
            return filter;
        }
    }
}