using DataAcsess.Models;
using DataAcsess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogic.Sercises
{
    public class AuthenticationServise
    {
        public SingIn LoggedUser { get; set; }

        public void AuthenticateUser(string username, string password)
        {
            UserRepository userRepo = new UserRepository();
            LoggedUser = userRepo.GetbyUsernameAndPassword(username, password);
        }
    }
}
