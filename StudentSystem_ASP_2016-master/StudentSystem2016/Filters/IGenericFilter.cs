using StudentSystem2016.VModels.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Filters
{
    public interface IGenericFilter
    {
        PagerVM Pager { get; set; }
        string Prefix { get; set; }
    }
}