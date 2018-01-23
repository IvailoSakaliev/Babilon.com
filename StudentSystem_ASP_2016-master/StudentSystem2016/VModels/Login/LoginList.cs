using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Login
{
    public class LoginList
        :GenericList<SingIn, LoginFilter>
    {
        public LoginList()
            :base()
        {

        }
    }
}