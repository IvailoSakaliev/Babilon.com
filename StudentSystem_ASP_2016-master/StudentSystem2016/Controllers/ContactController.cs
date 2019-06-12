using StudentSystem2016.Models;
using StudentSystem2016.Authentication;
using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.Servises.EntityServise;
using StudentSystem2016.Servises.ProjectServise;
using StudentSystem2016.VModels.Models.Contacts;
using System;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    
        [AuthenticationFilter]
        public class ContactController
         : Controller

        {
            private IEncriptServises _encript = new EncriptServises();
            private ContactServise _contact = new ContactServise();
            private static string _emailUser;
            private static string _emailSubjec;
            private static int _emailID;

           

            [HttpPost]
            public JsonResult ChangeEmailInformation(int id)
            {
                Contact contact = new Contact();
                Contact item = _contact.GetByID(id);
                contact.Message = _encript.DencryptData(item.Message);
                contact.Email = _encript.DencryptData(item.Email);
                contact.Name = _encript.DencryptData(item.Name);
                contact.Date = item.Date;
                return Json(contact);
            }

            //[HttpPost]
            //public JsonResult DeleteEmail(int id)
            //{
            //    _contact.DeleteById(id);
            //    return Json("ok");
            //}            //[HttpPost]
            //public JsonResult DeleteEmail(int id)
            //{
            //    _contact.DeleteById(id);
            //    return Json("ok");
            //}

            [HttpGet]
            public ActionResult SendEmailTOUser(int id)
            {
                ContactVm model = new ContactVm();
                Contact user = _contact.GetByID(id);
                _emailUser = user.Email;
                _emailSubjec = _encript.DencryptData(user.Name);
                _emailID = id;
                return View(model);
            }

            [HttpPost]
            public ActionResult SendEmailTOUser(ContactVm model)
            {
                Login login = new Login();
                login.Email = _emailUser;
                login.ID = 0;

                Contact entity = new Contact();
                entity.Email = _emailUser;
                entity.Name = _emailSubjec;
                entity.Message = model.Message;
                try
                {
                    EmailServises _email = new EmailServises(login);
                    _email.SendEmailFromAdmin(3, entity);
                    //DeleteEmail();
                }
                catch (Exception)
                {

                    throw;
                }


                return Redirect("../Index?Curentpage=1");
            }

            //private void DeleteEmail()
            //{
            //    _contact.DeleteById(_emailID);
            //}
        }
    
}