﻿namespace DataAcsess.Models
{
    public class Persone : BaseModel
    {

        public string LastName { get; set; }
        public string Email { get; set; }
        public SingIn Login_id { get; set; }

    }
   
}
