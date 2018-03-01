using DataAcsess.Models;
using StudentSystem2016.Authentication;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Login;
using System.Web.Mvc;
using BissnessLogic.Sercises;
using DataAcsess.Repository;
using System;
using StudentSystem2016.VModels.Students;
using DataAcsess.Enum;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        :GenericController<SingIn,EditVM, LoginList, LoginFilter, SingInServise>
    {
        AuthenticationServise authenticateService = new AuthenticationServise();
        private GenericRepository<SingIn> singin;
        
        [HttpGet]
        public ActionResult Login()
        {
            LoginVM login = new LoginVM();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            authenticateService.AuthenticateUser(model.UserName, model.Password);
            if (authenticateService.LoggedUser != null)
            {
                return Redirect("../Student/Details");
            }
            model = new LoginVM();
            return View(model);

        }
        [HttpGet]
        public ActionResult Register()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(EditVM model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                SingInServise servise = new SingInServise();
                SingIn reg = new SingIn();

                reg.Name = model.Name;
                reg.LastName = model.LastName;
                reg.Email = model.Email;
                reg.Username = model.Username;
                reg.Password = model.Password;

                servise.Save(reg);

                return View(new EditVM());
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationServise.LoggOut();
            return Redirect("Home/Index");
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
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Username = model.Username;
            if (model.Password == model.ConfirmPassword)
            {
                entity.Password = model.Password;
            }
            else
            {
                //error messegea
            }
            entity.Role = Roles.Student;
            return entity;

        }
    }
}