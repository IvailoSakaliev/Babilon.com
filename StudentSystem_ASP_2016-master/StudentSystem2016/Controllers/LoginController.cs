using DataAcsess.Models;
using StudentSystem2016.Servises.EntityServise;
using StudentSystem2016.Servises.ProjectServise;
using StudentSystem2016.VModels.Models.Login;
using StudentSystem2016.VModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class LoginController : Controller
    {
        //private AuthenticationService _aut = new AuthenticationService();
        //private IEncriptServises _encript = new EncriptServises();
        //private LoginServise _servise = new LoginServise();
        //private static int userid;

        [HttpGet]
        public ActionResult Index()
        {
            LoginVM login = new LoginVM();
            try
            {

                if (Request.Cookies["UserInformation"] != null)
                {
                    //login.Email = _encript.DencryptData(Request.Cookies["UserInformation"].Values["user"].ToString());
                    //login.Password = _encript.DencryptData(Request.Cookies["UserInformation"].Values["pass"].ToString());
                }
            }
            catch (ArgumentNullException ex)
            {

                return View(login);
            }

            return View(login);
        }

        //[HttpPost]
        //public ActionResult Index(LoginVM login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //int id = _aut.AuthenticateUser(login.Email, login.Password, 1, 1);
        //        if (id != 0)
        //        {
        //            if (id == -1)
        //            {
        //                ModelState.AddModelError(string.Empty, "Please go to your email to active yout account!");
        //                return View();
        //            }
        //            else
        //            {
        //                GoToSession();
        //                if (login.RememberME)
        //                {
        //                    CreateCookie(login);
        //                }
        //                return Redirect("../");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "This user is't exist in this site. Please go ot Create account to registed");

        //        }
        //        return View();
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ForgotPassM model = new ForgotPassM();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult ForgotPassword(ForgotPassM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Login login = new Login();
        //        //List<Login> list = _servise.GetAll(x => x.Email == _encript.EncryptData(model.Email));
        //        if (list.Count != 0)
        //        {
        //            EmailServises _email = new EmailServises(list[0]);
        //            _email.SendEmail(2);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Тhis email is not in our system.");
        //            return View();

        //        }
        //    }
        //    return RedirectToAction("GoToEmail");
        //}
        //[HttpGet]
        //public ActionResult GoToEmail()
        //{

        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Confirm()
        //{

        //    return View();
        //}

        [HttpGet]
        public ActionResult Registration()
        {
            RegistrationVM model = new RegistrationVM();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Registration(RegistrationVM reg)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (CheckForExitedUserInDB(reg))
        //        {
        //            ModelState.AddModelError(string.Empty, "Email already exist in site. Please enter anoither emeil");
        //            return View(reg);
        //        }
        //        else
        //        {

        //            string error = EnterLoginInformation(reg);
        //            if (error != "OK")
        //            {
        //                ModelState.AddModelError(string.Empty, error);
        //                return View(reg);
        //            }
        //            else
        //            {
        //                AddUSerINformation(reg);

        //            }
        //        }

        //    }
        //    return RedirectToAction("Confirm");
        //}

        //private User AddUSerINformation(RegistrationVM reg)
        //{
        //    List<Login> list = new List<Login>();
        //    list = _servise.GetAll(x => x.Email == _encript.EncryptData(reg.Email));
        //    User user = new User();
        //    user.LoginID = list[0].ID;
        //    user.Name = _encript.EncryptData(reg.FirstName);
        //    user.SecondName = _encript.EncryptData(reg.SecondName);
        //    user.City = _encript.EncryptData(reg.City);
        //    user.Adress = _encript.EncryptData(reg.Adress);
        //    user.Telephone = _encript.EncryptData(reg.Telephone);
        //    user.Image = "../images/userIcon.png";
        //    UserServise _userServise = new UserServise();
        //    _userServise.Save(user);
        //    return user;
        //}

        //private string EnterLoginInformation(RegistrationVM reg)
        //{
        //    Login login = new Login();
        //    LoginVM loginVm = new LoginVM();
        //    login.Email = _encript.EncryptData(reg.Email);
        //    if (reg.Password == reg.ConfirmPassword)
        //    {
        //        login.Password = _encript.EncryptData(reg.Password);

        //        if (!_servise.CheckForAdmin())
        //        {
        //            login.isRegisted = true;
        //            login.Role = 1;
        //            _servise.Save(login);

        //            loginVm.Email = reg.Email;
        //            loginVm.Password = reg.Password;
        //            CreateCookie(loginVm);



        //        }
        //        else
        //        {
        //            login.isRegisted = false;
        //            login.Role = 2;
        //            _servise.Save(login);

        //            login = new Login();
        //            login = _servise.GetLastElement();
        //            EmailServises _email = new EmailServises(login);
        //            _email.SendEmail(1);
        //        }



        //    }
        //    else
        //    {
        //        return "Password no match";
        //    }

        //    return "OK";
        //}

        //[HttpGet]
        //public ActionResult EnableAccount(int id)
        //{
        //    Login entity = new Login();
        //    entity = _servise.GetByID(id);
        //    entity.isRegisted = true;
        //    _servise.Save(entity);
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult RestorePassword(string id)
        //{
        //    userID = int.Parse(_encript.DencryptData(id));
        //    RegistrationVM model = new RegistrationVM();
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult RestorePassword(RegistrationVM model)
        //{
        //    if (model.Password == model.ConfirmPassword)
        //    {
        //        Login entity = _servise.GetByID(userID);
        //        entity.Password = _encript.EncryptData(model.Password);
        //        _servise.Save(entity);
        //        return RedirectToAction("SuccessChangePassword");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Паролите не съвпадат !");
        //        return View(model);
        //    }


        //}

        //[HttpGet]
        //public ActionResult SuccessChangePassword()
        //{
        //    return View();
        //}
        //private void GoToSession()
        //{
        //    Session["LoggedUser"] = _encript.EncryptData(_aut._LoggedUser.Role.ToString());

        //    Session["UserFirstName"] =  _encript.EncryptData(_aut._LoggedUser.Email);

        //    Session["User_ID"] = _aut._LoggedUser.ID.ToString();
        //}

        //[HttpGet]
        //public ActionResult LoggOut()
        //{

        //    _aut._LoggedUser = null;
        //    HttpContext.Session.Remove("LoggedUser");

        //    HttpContext.Session.Remove("UserFirstName");

        //    HttpContext.Session.Remove("User_ID");

        //    return RedirectToAction("Index");

        //}

        //public bool CheckForExitedUserInDB(RegistrationVM model)
        //{
        //    if (_aut.AuthenticateUser(model.Email, model.Password, 2, 2) != 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public void CreateCookie(LoginVM model)
        //{

        //    HttpCookie cookie = new HttpCookie("UserInformation");
        //    cookie.Values["UserEmail"] = _encript.EncryptData(model.Email);
        //    cookie.Values["Userpassword"] = _encript.EncryptData(model.Password);
        //    cookie.Expires = DateTime.Now.AddDays(30);
        //    HttpContext.Response.Cookies.Add(cookie);

        //}
        //public LoginVM GetInformation()
        //{
        //    LoginVM login = new LoginVM();
        //    HttpCookie cookie = HttpContext.Request.Cookies["UserInformation"];
        //    login.Email = cookie["UserEmail"];
        //    login.Password = cookie["Userpassword"];
        //    return login;
        //}

        //[HttpGet]
        //[UserFilter]
        //public ActionResult Details(int id)
        //{
        //    //TEntity entity = new TEntity();
        //    //TeidtVM model = new TeidtVM();
        //    //entity = _Servise.GetByID(id);
        //    //model = PopulateModelToItem(entity, model);
        //    return View();
        //}


    }

}