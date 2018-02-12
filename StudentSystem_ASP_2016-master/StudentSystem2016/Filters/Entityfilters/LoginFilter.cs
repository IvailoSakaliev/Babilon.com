using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using StudentSystem2016.Atributes;

namespace StudentSystem2016.Filters.Entityfilters
{
    public class LoginFilter
        : GenericFiler<SingIn>
    {
        [FilterProperty(DisplayName = "Username")]
        public string Username { get; set; }

        [FilterProperty(DisplayName = "Password")]
        public string Password { get; set; }

        [FilterProperty(DisplayName = "Name")]
        public string Name { get; set;}

        [FilterProperty(DisplayName = "LastName")]
        public string LastName { get; set; }

        [FilterProperty(DisplayName = "Email")]
        public string Email { get; set; }


        public override Expression<Func<SingIn, bool>> BildFilter()
        {
            Expression<Func<SingIn, bool>> filter =
                u => (string.IsNullOrEmpty(this.Name) || u.Name.Contains(this.Name.Trim()))
                && (string.IsNullOrEmpty(this.LastName) || u.LastName.Contains(this.LastName.Trim()))
                && (string.IsNullOrEmpty(this.Username) || u.Username.Contains(this.Username.Trim()))
                && (string.IsNullOrEmpty(this.Password) || u.Password.Contains(this.Password.Trim()))
                && (string.IsNullOrEmpty(this.Email) || u.Email.Contains(this.Email.Trim()));
            return filter;
               
        }
    }
}