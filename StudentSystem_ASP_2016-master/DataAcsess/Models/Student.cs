using DataAcsess.Enum;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Student : Persone
    {
        public string FacultetNumber { get; set; }
        public int Course { get; set; }
        public int Groups { get; set; }
        public string Inspector { get; set; }
        public OKS OKS { get; set; }
        public string Inmage { get; set; }
        public string Mobile { get; set; }

        public virtual Specialty Specialnost { get; set; }
        public virtual Facultet Facultet { get; set; }
    }
}
