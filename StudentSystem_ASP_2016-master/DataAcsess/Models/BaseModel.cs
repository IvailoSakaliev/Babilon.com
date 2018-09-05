using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
   
    public class BaseModel
        :Parent
    {
        public string Name { get; set; }
    }
}
