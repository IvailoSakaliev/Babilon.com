using DataAcsess.Enum;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class SingIn :BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Employeee { get; set; }
        
        

    }
}
