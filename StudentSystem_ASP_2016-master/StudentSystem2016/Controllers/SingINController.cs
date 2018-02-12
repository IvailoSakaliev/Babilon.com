using DataAcsess.Models;
using StudentSystem2016.Authentication;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Login;
using System.Web.Mvc;
using BissnessLogic.Sercises;
using DataAcsess.Repository;
using System;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        :GenericController<SingIn,RegisterVM, LoginList, LoginFilter, SingInServise>
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

            AuthenticationManager.Authenticate(model.UserName, model.Password);
            if (authenticateService.LoggedUser != null)
            {
                //return Redirect()
            }            
            
            //Redirect
            return View();

        }
        [HttpGet]
        public ActionResult Register()
        {
            RegisterVM model = new RegisterVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
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

                return View(new RegisterVM());
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.Logout();
            return Redirect("Home/Index");
        }

        public override SingIn PopulateItemToModel(RegisterVM model, SingIn entity)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.Email = model.Email;
            return entity;
        }

        public override RegisterVM PopulateModelToItem(SingIn entity, RegisterVM model)
        {
            model.Name = entity.Name;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Email = entity.Email;
            return model;
        }
    }
}