using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Specialties;
using System.Web.Mvc;
using SS.SpecilatyServise;
using System.Collections.Generic;
using StudentSystem2016.Authentication;

namespace StudentSystem2016.Controllers
{
    public class SpecialtyController 
        :GenericController<Specialty,EditVM, SpecialtyList, SpecialtyFilter, SpecilatyServise>
    {
        [AuthenticationFilter]
        public ActionResult DetailForStudentSpecilty(int? id)
        {
            SpecilatyServise servise = new SpecilatyServise();
            Specialty spec = new Specialty();
            spec = servise.GetByID(id);
            EditVM model = new EditVM();
            PopulateModelToItem(spec, model);
            return View(model);
        }

        

        public override Specialty PopulateEditItemToModel(EditVM model, Specialty entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public override Specialty PopulateItemToModel(EditVM model, Specialty entity)
        {
            entity.Name = model.Name;
            entity.Inspector = model.Inspector;
            entity.OKS = model.OKS;
            entity.YearOFStudy = int.Parse(model.YearOFStudy);
            return entity;
        }

        public override EditVM PopulateModelToItem(Specialty entity, EditVM model)
        {
            model.Name = entity.Name;
            model.Inspector = entity.Inspector;
            model.OKS = entity.OKS;
            model.YearOFStudy = entity.YearOFStudy.ToString();
            return model;
        }
       
    }
}