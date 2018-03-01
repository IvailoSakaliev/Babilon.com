using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Subject : BaseModel
    {
        public int Course { get; set; }
        public int Semester { get; set; }
        
    }
}
