using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.VModels.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class LectorController : Controller
    {
        // GET: Lector
        public ActionResult Edit()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            LectureServise servise = new LectureServise();
            Lecture lector = new Lecture();

            lector.Name = model.Name;
            lector.LastName = model.LastName;
            lector.Username = model.EGN;
            lector.Password = model.Password;
            lector.Email = model.Email;
            lector.Kabinet = int.Parse(model.Kabinet);
            lector.Mobile = model.Mobile;

            servise.Save(lector);

            LectorServise registre = new LectorServise();
            SingIn registrateUser = new SingIn();
            registrateUser.UserName = lector.Username;
            registrateUser.Password = lector.Password;
            registrateUser.Employeee = 1;

            registre.Save(registrateUser);
            return View();
        }
    }
}