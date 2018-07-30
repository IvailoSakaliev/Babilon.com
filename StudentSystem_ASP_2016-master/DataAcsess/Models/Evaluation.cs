    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Evaluation
        :Parent
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
    }
}
