using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Scholarship : BaseModel
    {
        private ICollection<Student> student;
        public Scholarship()
        {
            this.student = new HashSet<Student>();
        }


        public int Srok { get; set; }
        public DateTime StartData { get; set; }
        public DateTime DeadLine { get; set; }
        public int Size { get; set; }

        public virtual ICollection<Student> Student
        {
            get
            {
                return this.student;
            }
            set
            {
                this.student = value;
            }
        }
    }
}
