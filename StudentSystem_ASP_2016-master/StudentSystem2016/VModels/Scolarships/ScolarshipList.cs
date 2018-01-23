using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Scolarships
{
    public class ScolarshipList
        :GenericList<Scholarship, ScollarShipFilter>
    {
        public ScolarshipList()
            :base()
        {

        }
    }
}