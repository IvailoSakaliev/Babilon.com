using StudentSystem2016.Models;
using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.Servises.EntityServise;
using StudentSystem2016.VModels.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class TypeController
       : Controller
    {
        private BaseTypeServise _baseServise = new BaseTypeServise();
        private static int _ItemID;

    }
}