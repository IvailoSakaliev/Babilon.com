using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;

namespace StudentSystem2016.VModels.Specialties
{
    public class SpecialtyList
        :GenericList<Specialty, SpecialtyFilter>
    {
        public SpecialtyList()
            :base()
        {
              
        }
    }
}