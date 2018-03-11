using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Lectures;
using System.Web.Mvc;
using StudentSystem2016.Authentication;
using SS.LectureServise;
using SS.AuthenticationServise;

namespace StudentSystem2016.Controllers
{
    public class LectorController : 
        GenericController<
            Lecture,
            LectorEditVM,
            LectorList, 
            LectorFilter,
            LectureServise>
    {
        AuthenticationServise authenticateService = new AuthenticationServise();

        public LectorController()
            :base()
        {

        }
        [HttpGet]
        [AuthenticationFilter]
        public ActionResult DetailsID(int id)
        {
            LectureServise servise = new LectureServise();
            Lecture entity = servise.GetByloginID(id);
            LectorEditVM model = new LectorEditVM();
            model = PopulateModelToItem(entity, model);
            return View("Details", model);
        }
        public override LectorEditVM PopulateModelToItem(Lecture entity, LectorEditVM model)
        {
            model.Name = entity.Name;
            model.LastName = entity.LastName;
            model.Email = entity.Email;
            model.Kabinet = entity.Kabinet.ToString();
            model.Mobile = entity.Mobile;
            return model;
        }

        public override Lecture PopulateItemToModel(LectorEditVM model, Lecture entity)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Kabinet = int.Parse(model.Kabinet);
            entity.Mobile = model.Mobile;
            entity.Login = base.login_id;
            return entity;
        }
        public override SingIn PopulateRegisterInfomationInModel(SingIn entity, LectorEditVM model)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.Email = model.Email;
            entity.Role = 3;
            return entity;
        }
        public override bool CheckForExitedUserInDB(LectorEditVM model)
        {
            authenticateService.AuthenticateUser(model.Username, model.Password, 1);
            if (authenticateService.LoggedUser != null)
            {
                return true;
            }
            return false;
        }
    }
}