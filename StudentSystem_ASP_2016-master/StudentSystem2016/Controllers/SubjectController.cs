using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Subjects;
using SS.SubjectServise;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using SS.SpecialtySubjectServise;
using SS.SpecialtyServise;

namespace StudentSystem2016.Controllers
{
    public class SubjectController
        : GenericController<Subject, EditVM, SubjectList, SubjectFilter, SubjectServise>
    {
        
        public override Subject PopulateEditItemToModel(EditVM model, Subject entity, int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public ActionResult AddSubject()
        {
            EditVM model = new EditVM();
            model = PopilateSelectListIthem(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubject(EditVM model)
        {
            string idSpecialty = Request.Form["specialty"].ToString(); ;
            Add(model);
            AddSubjetcWithSpecialty(idSpecialty);
            return View(model);
        }

        private void AddSubjetcWithSpecialty(string id)
        {
            SpecialtySubjectServise servise = new SpecialtySubjectServise();
            SubjectServise serviseSubject = new SubjectServise();
            SpecialtySubject entity = new SpecialtySubject();
            var subjects = serviseSubject.GetAll();
            entity = PopulateSubjectSpecialtyModel(entity,subjects, id);
            servise.Save(entity);

            
        }

        private SpecialtySubject PopulateSubjectSpecialtyModel(SpecialtySubject entity, List<Subject> subjects, string id)
        {
            entity.SubjectID = subjects[subjects.Count - 1].ID;
            entity.SpecialtyID = int.Parse(id);
            return entity;
        }

        public override Subject PopulateItemToModel(EditVM model, Subject entity)
        {
            entity.Name = model.Name;
            entity.Course = int.Parse(model.Course);
            entity.Semester = int.Parse(model.Semester);
            return entity;
        }

        public override EditVM PopulateModelToItem(Subject entity, EditVM model)
        {
            model.Name = entity.Name;
            model.Course = entity.Course.ToString();
            model.Semester = entity.Semester.ToString();
            return model;
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
            SpecialtyServise spec = new SpecialtyServise();
            var result = spec.GetAll();
            model.Specialty = GetSelectedListIthem(result);
            return model;
        }

    }
}