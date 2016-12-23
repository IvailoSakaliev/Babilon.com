using DataAcsess.Models;
using StudentSystem2016.Filters;
using StudentSystem2016.VModels.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels
{
    public class GenericList<Tentity, Tfilter>
        where Tentity: BaseModel
        where Tfilter : GenericFiler<Tentity>, new()
    {

        public IList<Tentity> Iteams { get; set; }
        public PagerVM Pager { get; set; }
        public Tfilter  Filter { get; set; }

        public GenericList()
        {
            this.Filter = new Tfilter();
            this.Pager = new PagerVM();
            this.Iteams = new List<Tentity>();

        }
    }
}