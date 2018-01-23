using DataAcsess.Models;
using StudentSystem2016.Authentication;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Login;
using System.Web.Mvc;
using BissnessLogic.Sercises;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        :GenericController<SingIn,LoginVM, LoginList, LoginFilter, SingInServise>
    {
        AuthenticationServise authenticateService = new AuthenticationServise();


        [HttpGet]
        public ActionResult Login()
        {
            LoginVM login = new LoginVM();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            AuthenticationManager.Authenticate(model.UserName, model.Password);
            if (authenticateService.LoggedUser != null)
            {
                //return Redirect()
            }            
            
            //Redirect
            return View();

        }
        
        public ActionResult Logout()
        {
            AuthenticationManager.Logout();
            return Redirect("Home/Index");
        }
        
    }
}