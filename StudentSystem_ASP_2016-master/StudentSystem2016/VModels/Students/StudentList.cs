
using StudentSystem2016.Filters;
using StudentSystem2016.Filters.Entityfilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcsess.Models;

namespace StudentSystem2016.VModels.Students
{
    public class StudentList 
        :GenericList<Student, StudentFilter>
    {
        public StudentList()
            :base()
        {

        }
    }
}