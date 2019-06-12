using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem2016.Models
{
    public class Images
       : BaseModel
    {
        public string Path { get; set; }
        public int Subject_id { get; set; }
    }
}
