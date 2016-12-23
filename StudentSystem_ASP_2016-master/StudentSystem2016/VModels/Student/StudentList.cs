using DataAcsess.Models;
using StudentSystem2016.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Student
{
    public class StudentList :GenericList<SingIn, AuturizationFilter>
    {
        public StudentList()
            :base()
        {

        }
    }
}