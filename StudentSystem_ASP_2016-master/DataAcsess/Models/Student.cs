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
        private ICollection<Subject> predmet;

        public Student()
        {
            this.predmet = new HashSet<Subject>();
        }

        public int Course { get; set; }
        public int Groups { get; set; }
        public OKS OKS { get; set; }
        public Scholarship Scholarship_ID { get; set; }
        public Specialty Specialty_ID { get; set; }

        public virtual ICollection<Subject> Predmet
        {
            get
            {
                return this.predmet;
            }
            set
            {
                this.predmet = value;
            }
        }



    }
}
