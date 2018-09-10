using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Login;
using System.Web.Mvc;
using StudentSystem2016.VModels.Students;
using SS.SingInServise;
using SS.AuthenticationServise;
using System.Collections.Generic;
using SS.EmailServise;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        : GenericController<SingIn, EditVM, LoginList, LoginFilter, SingInServises>
    {
        AuthenticationServises authenticateService = new AuthenticationServises();
        SingInServises singin = new SingInServises();

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM login = new LoginVM();
            List<string> loginInfo = new List<string>();
            loginInfo = singin.AutoLogin();
            if (loginInfo.Count == 2)
            {
                login.UserName = loginInfo[0];
                login.Password = loginInfo[1];
                login.Remember = false;
                Login(login);
                return Redirect("../Home/Index");
            }
            
            return View(login);
        }
        [HttpGet]
        public ActionResult Confirm(int? id)
        {
            SingInServises servise = new SingInServises();
            servise.ConfirmedRegistration(id);
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            authenticateService.AuthenticateUser(model.UserName, model.Password, 1);
            if (authenticateService.LoggedUser == null)
            {
                model = new LoginVM();
                return View(model);
            }
            else
            {
                if (model.Remember)
                {
                    singin.RememberMe(model.UserName, model.Password);
                }
                if (!SingInServises.IsConfirmRegistartion(authenticateService.LoggedUser))
                {
                    return View("../Student/GoToConfirm");
                }
                else
                {
                    return Redirect("../");
                }
            }
        }

        [HttpGet]
        public ActionResult EmailForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailForgotPassword(string email)
        {
            List<SingIn> users = singin.GetAll();
            var user = singin.ResetPassword(users, email);
            EmailServises emailServise = new EmailServises(user);
            emailServise.SendEmail(2);
            return View("GoToEmail");
        }

        [HttpGet]
        public ActionResult GoTOEmail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword(int? id)
        {
            Session["ChangePasswordUserID"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return View();
            }
            singin.ChangePassword((int)Session["ChangePasswordUserID"], password);
            return Redirect("../Login");
        }

        //back-end function
        public ActionResult Logout()
        {
            authenticateService.LoggOut();
            return Redirect("../");
        }

        public override SingIn PopulateItemToModel(EditVM model, SingIn entity)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.Email = model.Email;
            return entity;
        }
        public override EditVM PopulateModelToItem(SingIn entity, EditVM model)
        {
            model.Name = entity.Name;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Email = entity.Email;
            return model;
        }
        public override SingIn PopulateRegisterInfomationInModel(SingIn entity, EditVM model)
        {
            entity.Name = singin.EncriptServise.EncryptData(model.Name);
            entity.LastName = singin.EncriptServise.EncryptData(model.LastName);
            entity.Email = singin.EncriptServise.EncryptData(model.Email);
            entity.Username = singin.EncriptServise.EncryptData(model.Username);
            entity.Password = singin.EncriptServise.EncryptData(model.Password);

            if (model.Password == model.ConfirmPassword)
            {
                entity.Password = model.Password;
            }
            else
            {
                //error messegea
            }
            entity.Role = 2;
            return entity;

        }
        public override bool CheckForExitedUserInDB(EditVM model)
        {
            authenticateService.AuthenticateUser(model.Username, model.Password,1);
            if (authenticateService.LoggedUser != null)
            {
                return true;
            }
            return false;
        }

        public override SingIn PopulateEditItemToModel(EditVM model, SingIn entity, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}