using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Subjects;
using System.Web.Mvc;
using System;

namespace StudentSystem2016.Controllers
{
    public class SubjectController 
        :GenericController<Subject, EditVM, SubjectList, SubjectFilter, SubjectServise> 
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

        public override Subject PopulateItemToModel(EditVM model, Subject entity)
        {
            throw new NotImplementedException();
        }

        public override EditVM PopulateModelToItem(Subject entity, EditVM model)
        {
            throw new NotImplementedException();
        }
    }
}