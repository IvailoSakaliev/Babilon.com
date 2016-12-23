using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.VModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        [HttpGet]
        public ActionResult Edit()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            SubjectServise servise = new SubjectServise();
            Subject subject = new Subject();
            subject.Name = model.Name;
            subject.Course = int.Parse(model.Course);
            subject.Semester = int.Parse(model.Semester);

            servise.Save(subject);
            return View();
        }
    }
}