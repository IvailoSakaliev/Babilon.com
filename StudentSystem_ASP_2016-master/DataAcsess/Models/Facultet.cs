using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Facultet : BaseModel
    {
        private ICollection<Specialty> specialty;
        private ICollection<Lecture> lecture;
        private ICollection<Student> student;

        public Facultet()
        {
            this.specialty = new HashSet<Specialty>();
            this.lecture = new HashSet<Lecture>();
            this.student = new HashSet<Student>();
        }

        public virtual ICollection<Specialty> Specialty
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }
        public virtual ICollection<Lecture> Lectures
        {
            get { return this.lecture; }
            set { this.lecture = value; }
        }
        public virtual ICollection<Student> Student
        {
            get { return this.student; }
            set { this.student = value; }
        }

    }
}
