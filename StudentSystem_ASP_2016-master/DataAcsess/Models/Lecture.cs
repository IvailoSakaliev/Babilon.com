using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Lecture : Persone
    {
        //private ICollection<Subject> predmet;

        //public Lecture()
        //{
        //    this.predmet = new HashSet<Subject>();
        //}
        public int Kabinet { get; set; }
        public string Mobile { get; set; }

        //public virtual ICollection<Subject> Predmet
        //{
        //    get
        //    {
        //        return this.predmet;
        //    }
        //    set
        //    {
        //        this.predmet = value;
        //    }
        //}


    }
}
