using DataAcsess.Models;
using StudentSystem2016.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class LectorFilter
        : GenericFiler<Lecture>
    {
        public LectorFilter()
        {

        }

        [FilterProperty(DisplayName = "First name")]
        public string Name { get; set; }

        [FilterProperty(DisplayName = "Last name")]
        public string LastName { get; set; }

        [FilterProperty(DisplayName = "Email")]
        public string Email { get; set; }

        public override Expression<Func<Lecture, bool>> BildFilter()
        {
            Expression<Func<Lecture, bool>> filter =
                u => (string.IsNullOrEmpty(this.Name) || u.Name.Contains(this.Name.Trim()))
                && (string.IsNullOrEmpty(this.LastName) || u.LastName.Contains(this.LastName.Trim()));
                return filter;
        }
    }
}