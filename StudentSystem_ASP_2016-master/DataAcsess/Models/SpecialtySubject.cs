using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class SpecialtySubject
    {
        public int ID { get; set; }
        public Specialty Specialty { get; set; }
        public Subject Subject {get; set;}
    }
}
