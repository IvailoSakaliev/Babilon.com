using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.BaseTypes
{
    public class BaseTypeList
       : GenericList<BaseType, BaseTypeFilter>
    {
        public BaseTypeList()
            : base()
        {

        }
    }
}