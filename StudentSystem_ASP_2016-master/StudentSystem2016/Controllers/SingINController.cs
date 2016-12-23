using BissnessLogic.Sercises;
using DataAcsess.Models;
using DataAcsess.Repository;
using DataAcsess.UnitOfWork;
using StudentSystem2016.Authentication;
using StudentSystem2016.VModels;
using StudentSystem2016.VModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    [AuthenticationFilter]
    public class SingINController:Controller
    {       
        
        [HttpGet]
        public ActionResult Login()
        {
            
            LoginVM login = new LoginVM();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            return View();

        }

        public ActionResult Logout()
        {
            return View();
        }
        
    }
}