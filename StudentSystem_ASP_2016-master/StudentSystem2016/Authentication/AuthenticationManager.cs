using BissnessLogic.Sercises;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Authentication
{
    public class AuthenticationManager
    {
        public static SingIn LoggedUser
        {
            get
            {
                AuthenticationServise authenticationService = null;
                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                    HttpContext.Current.Session["LoggedUser"] = new AuthenticationServise();
                authenticationService = (AuthenticationServise)HttpContext.Current.Session["LoggedUser"];
                return authenticationService.LoggedUser;
            }
        }
        public static void Authenticate(string username, string password)
        {
            AuthenticationServise authenticationService = null;
            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                HttpContext.Current.Session["LoggedUser"] = new AuthenticationServise();
            authenticationService = (AuthenticationServise)HttpContext.Current.Session["LoggedUser"];
            authenticationService.AuthenticateUser(username, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }

    }
}