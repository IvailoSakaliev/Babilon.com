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
using static System.Collections.Specialized.BitVector32;
using System.Collections.Generic;
using SS.SpecialtyServise;

namespace StudentSystem2016.Controllers
{

    public class StudentController 
        : GenericController<Student, EditVM, StudentList, StudentFilter, StudentServises>
    {
        SingInServises singin = new SingInServises();
        AuthenticationServises authenticateService = new AuthenticationServises();

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
            StudentServises servise = new StudentServises();
            Student entity = servise.GetByloginID(id);
            EditVM model = new EditVM();
            model = PopulateModelToItem(entity, model);
            return View("Details", model);
        }

        public override Student PopulateEditItemToModel(EditVM model, Student entity, int id)
        {
            try
            {
                entity.ID = id;
                entity.Name = model.Name;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Course = int.Parse(model.Course);
                entity.Groups = int.Parse(model.Groups);
                entity.Login = (int)Session["loginID"];
               

            }
            catch (NullReferenceException)
            {
                
            }

            return entity;
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
                entity.Specialties = int.Parse(Request.Form["specialty"].ToString());


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
                Session["loginID"] = entity.Login;
                
            }
            catch (NullReferenceException)
            {
                
            }
            return model;
        }

        public override SingIn PopulateRegisterInfomationInModel(SingIn entity, EditVM model)
        {
            entity.Name = singin.EncriptServise.EncryptData(model.Name);
            entity.LastName = singin.EncriptServise.EncryptData(model.LastName);
            entity.Email = singin.EncriptServise.EncryptData(model.Email);
            entity.Username = singin.EncriptServise.EncryptData(model.Username);
            
            if (model.Password == model.ConfirmPassword)
            {
                entity.Password = singin.EncriptServise.EncryptData(model.Password);
            }
            else
            {
                entity = null;
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
                return false;
            }
            return true;
        }

        // ithem list specialty
        private IEnumerable<SelectListItem> GetSelectedListIthem(List<Specialty> result)
        {
            var selectedList = new List<SelectListItem>();
            for (int i = 0; i < result.Count; i++)
            {
                selectedList.Add(new SelectListItem
                {
                    Value = result[i].ID.ToString(),
                    Text = result[i].Name.ToString()
                });
            }

            return selectedList;
        }
        public override EditVM PopilateSelectListIthem(EditVM model)
        {
            SpecialtyServises spec = new SpecialtyServises();
            var result = spec.GetAll();
            model.Specialty = GetSelectedListIthem(result);
            return model;
        }
    }
}