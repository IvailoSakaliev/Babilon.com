using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Login;
using System.Web.Mvc;
using StudentSystem2016.VModels.Students;
using SS.SingInServise;
using SS.AuthenticationServise;

namespace StudentSystem2016.Controllers
{
    public class SingINController
        :GenericController<SingIn,EditVM, LoginList, LoginFilter, SingInServise>
    {
        AuthenticationServise authenticateService = new AuthenticationServise();
        SingInServise singin = new SingInServise();

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM login = new LoginVM();
            return View(login);
        }
        [HttpGet]
        public ActionResult Confirm(int ? id)
        {
            SingInServise servise = new SingInServise();
            servise.ConfirmedRegistration(id);
            return View();
        }

        
        
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            authenticateService.AuthenticateUser(model.UserName,model.Password,1);
            if (authenticateService.LoggedUser == null)
            {
                model = new LoginVM();
                return View(model);
            }
            else
            {
                if (!SingInServise.IsConfirmRegistartion(authenticateService.LoggedUser))
                {
                    return View("../Student/GoToConfirm");
                }
                else
                {
                    return Redirect("../");
                }
            }
            
            

        }
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
            entity.Name = singin.EncryptData(model.Name);
            entity.LastName = singin.EncryptData(model.LastName);
            entity.Email = singin.EncryptData(model.Email);
            entity.Username = singin.EncryptData(model.Username);
            entity.Password = singin.EncryptData(model.Password);

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
    }
}