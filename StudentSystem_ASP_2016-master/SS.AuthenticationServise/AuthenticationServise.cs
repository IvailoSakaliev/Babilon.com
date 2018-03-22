using DataAcsess.Models;
using DataAcsess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.AuthenticationServise
{
    public class AuthenticationServise
    {
        public SingIn LoggedUser { get; set; }
        public int Login_id { get; set; }
        private List<SingIn> list { get; set; }

        public void AuthenticateUser(string username, string password, int state)
        {
            UserRepository repo = new UserRepository();
            this.list = repo.GetAll((u) => u.Username == username && u.Password == password).ToList();

            this.LoggedUser = list.Count > 0 ? list[0] : null;
            
            if (this.LoggedUser != null)
            {
                if (state == 1)
                {
                    if (SingInServise.SingInServise.IsConfirmRegistartion(this.LoggedUser) == true)
                    {
                        GoToSession();
                    }
                }
                else if (state == 2)
                {
                    ReturnIdFromUser();
                }
            }
        }

        private void ReturnIdFromUser()
        {
            this.Login_id = LoggedUser.ID;
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
            HttpContext.Current.Session["UserFirstName"] = "";
            HttpContext.Current.Session["User_ID"] = null;
        }
    }
}
