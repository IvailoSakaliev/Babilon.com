using BissnessLogic.Sercises;
using StudentSystem2016.Authentication;
using StudentSystem2016.VModels.Login;
using StudentSystem2016.VModels.Student;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        :Controller
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