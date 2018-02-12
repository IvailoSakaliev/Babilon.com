using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Scolarships;
using System.Web.Mvc;
using System;

namespace StudentSystem2016.Controllers
{
    public class ScolarshipController
        :GenericController<Scholarship,ScolarshipEditVM, ScolarshipList, ScollarShipFilter, ScolarshipServise>
    {
        
        public override Scholarship PopulateItemToModel(ScolarshipEditVM model, Scholarship entity)
        {
            entity.Name = model.Name;
            entity.Size = int.Parse(model.Size);
            entity.Srok = int.Parse(model.Srok);
            entity.StartData = model.StartData;
            entity.DeadLine = model.DeadLine;
            return entity;

        }

        public override ScolarshipEditVM PopulateModelToItem(Scholarship entity, ScolarshipEditVM model)
        {
            model.Name = entity.Name;
            model.Size = entity.Size.ToString();
            model.Srok = entity.Srok.ToString();
            model.StartData = entity.StartData;
            model.DeadLine = entity.DeadLine;
            return model;
        }
    }
}