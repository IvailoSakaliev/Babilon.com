using DataAcsess.Models;
using DataAcsess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BissnessLogic.Sercises
{
    public class AuthenticationServise
    {
        public SingIn  LoggedUser { get; set; }

        public void AuthenticateUser(string username, string password)
        {
            UserRepository repo = new UserRepository();
            List<SingIn> users = repo.GetAll((u) => u.Username == username && u.Password == password).ToList();

            this.LoggedUser = users.Count > 0 ? users[0] : null;
            if (this.LoggedUser != null)
            {
                GoToSession();
            }
        }

        private void GoToSession()
        {
            HttpContext.Current.Session["LoggedUser"] = this.LoggedUser;
        }

        public static void LoggOut()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}
