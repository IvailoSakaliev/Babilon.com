using DataAcsess.Enum;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Specialty : BaseModel
    {
        //private ICollection<Lecture> lectures;

        //public Specialty()
        //{
        //    this.lectures = new HashSet<Lecture>();
        //}

        public int YearOFStudy { get; set; }
        public string Inspector { get; set; }
        public OKS OKS { get; set; }


        //public virtual ICollection<Lecture> Lecture
        //{
        //    get
        //    {
        //        return this.lectures;
        //    }
        //    set
        //    {
        //        this.lectures = value;
        //    }
        //}

    }
}
