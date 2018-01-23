using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Controllers;
using StudentSystem2016.Filters;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels;
using StudentSystem2016.VModels.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public LectorController()
            :base()
        {

        }

        // GET: Lector
        [HttpGet]
        public ActionResult Edit()
        {
            LectorEditVM model = new LectorEditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(LectorEditVM model)
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

            LecturServise registre = new LecturServise();
            SingIn registrateUser = new SingIn();
            registrateUser.UserName = lector.Username;
            registrateUser.Password = lector.Password;
            registrateUser.Employeee = 1;

            registre.Save(registrateUser);
            return View(model);
        }
    }
}