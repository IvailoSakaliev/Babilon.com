using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Specialties;
using System.Web.Mvc;
using System;

namespace StudentSystem2016.Controllers
{
    public class SpecialtyController 
        :GenericController<Specialty,EditVM, SpecialtyList, SpecialtyFilter, SpecilatyServise>
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

        public override Specialty PopulateItemToModel(EditVM model, Specialty entity)
        {
            throw new NotImplementedException();
        }

        public override EditVM PopulateModelToItem(Specialty entity, EditVM model)
        {
            throw new NotImplementedException();
        }
    }
}