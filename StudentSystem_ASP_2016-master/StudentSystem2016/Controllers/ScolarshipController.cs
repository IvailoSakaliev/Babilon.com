using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.VModels.Scolarship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class ScolarshipController : Controller
    {
        [HttpGet]
        public ActionResult Edit()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            ScolarshipServise servise = new ScolarshipServise();
            Scholarship scolarship = new Scholarship();
            scolarship.Name = model.Name;
            scolarship.Size = int.Parse(model.Size);
            scolarship.Srok = int.Parse(model.Srok);
            scolarship.StartData = model.StartData;
            scolarship.DeadLine = model.DeadLine;

            servise.Save(scolarship);
            return View();
        }
    }
}