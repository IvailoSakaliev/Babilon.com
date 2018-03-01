using System;

namespace DataAcsess.Models
{
    public class Scholarship : BaseModel
    {
        public int Srok { get; set; }
        public DateTime StartData { get; set; }
        public DateTime DeadLine { get; set; }
        public int Size { get; set; }

        
    }
}
