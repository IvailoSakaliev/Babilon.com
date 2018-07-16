using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Students;
using System;
using DataAcsess.Enum;
using System.Web.Mvc;
using StudentSystem2016.Authentication;
using SS.AuthenticationServise;
using SS.StudentServise;
using SS.SingInServise;

namespace StudentSystem2016.Controllers
{

    public class StudentController 
        : GenericController<Student, EditVM, StudentList, StudentFilter, StudentServise>
    {
        SingInServise singin = new SingInServise();
        AuthenticationServise authenticateService = new AuthenticationServise();

        public StudentController()
            :base()
        {

        }

        [HttpGet]
        public ActionResult GoToConfirm()
        {
            return View();
        }
        [HttpGet]
        [AuthenticationFilter]
        public ActionResult DetailsID(int id)
        {
            StudentServise servise = new StudentServise();
            Student entity = servise.GetByloginID(id);
            EditVM model = new EditVM();
            model = PopulateModelToItem(entity, model);
            return View("Details", model);
        }

        public override Student PopulateItemToModel(EditVM model, Student entity)
        {
            try
            {
                entity.Name = model.Name;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Course = int.Parse(model.Course);
                entity.Groups = int.Parse(model.Groups);
                entity.Login = base.login_id;
            }
            catch (NullReferenceException)
            {
                
            }

            return entity;
        }

        public override EditVM PopulateModelToItem(Student entity, EditVM model)
        {
            try
            {
                model.Name = entity.Name;
                model.LastName = entity.LastName;
                model.Course = entity.Course.ToString();
                model.Email = entity.Email;
                model.Groups =entity.Groups.ToString();
                model.OKS = entity.OKS;

                
            }
            catch (NullReferenceException)
            {
                
            }
            return model;
        }
        public override SingIn PopulateRegisterInfomationInModel(SingIn entity, EditVM model)
        {
            entity.Name = singin.EncryptData(model.Name);
            entity.LastName = singin.EncryptData(model.LastName);
            entity.Email = singin.EncryptData(model.Email);
            entity.Username = singin.EncryptData(model.Username);

            if (model.Password == model.ConfirmPassword)
            {
                entity.Password = singin.EncryptData(model.Password);
            }
           
            if (model.Role != Roles.Student)
            {
                entity.Role = RoleAnotation(model.Role);
            }
            else
            {
                entity.Role = 2;
            }
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