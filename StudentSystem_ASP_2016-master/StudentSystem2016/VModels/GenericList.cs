using DataAcsess.Models;
using StudentSystem2016.Filters;
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
        public IList<Tentity> Items{ get; set; }
        public IList<Tentity> AllItems{ get; set; }
        public int Pages { get; set; }
        public string ControllerName { get; set; }
        public int  StartItem { get; set; }
        public string ActionName { get; set; }
        public Tfilter  Filter { get; set; }

        public GenericList()
        {
            this.Filter = new Tfilter();
            this.Items = new List<Tentity>();
        }
        

    }
}