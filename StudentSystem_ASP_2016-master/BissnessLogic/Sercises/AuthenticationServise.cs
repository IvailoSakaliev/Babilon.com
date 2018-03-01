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
            HttpContext.Current.Session["LoggedUser"] = LoggedUser.Role;
            HttpContext.Current.Session["UserFirstName"] = LoggedUser.Name;
            HttpContext.Current.Session["User_ID"] = LoggedUser.ID;

        }

        public void LoggOut()
        {

            this.LoggedUser = null;
            HttpContext.Current.Session["LoggedUser"] = null;
            HttpContext.Current.Session["UserFirstName"] = "" ;
            HttpContext.Current.Session["User_ID"] = null;
        }
    }
}
