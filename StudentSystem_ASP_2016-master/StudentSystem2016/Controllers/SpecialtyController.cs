using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.VModels.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class SpecialtyController : Controller
    {
        // GET: Specialty
        [HttpGet]
        public ActionResult Edit()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            SpecilatyServise servise = new SpecilatyServise();
            Specialty specialty = new Specialty();
            specialty.Name = model.Name;
            specialty.YearOFStudy = int.Parse(model.YearOFStudy);
            specialty.Inspector = model.Inspector;
            specialty.OKS = model.OKS;

            servise.Save(specialty);

            return View();
        }
    }
}