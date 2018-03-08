using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using StudentSystem2016.Atributes;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class StudentFilter
        : GenericFiler<Student>
    {
        [FilterProperty(DisplayName = "FacultetNumber")]
        public string FacultetNumber { get; set; }

        [FilterProperty(DisplayName = "Inspector")]
        public string Inspector { get; set; }

        [FilterProperty(DisplayName = "Name")]
        public string Name { get; set; }

        [FilterProperty(DisplayName = "LastName")]
        public string LastName { get; set; }

        [FilterProperty(DisplayName = "Email")]
        public string Email { get; set; }

        public override Expression<Func<Student, bool>> BildFilter()
        {
            Expression<Func<Student, bool>> filter =
                u => (string.IsNullOrEmpty(this.Name) || u.Name.Contains(this.Name)) &&
                (string.IsNullOrEmpty(this.LastName) || u.LastName.Contains(this.LastName)) &&
                (string.IsNullOrEmpty(this.Email) || u.Email.Contains(this.Email));

            return filter;
        }
    }
}