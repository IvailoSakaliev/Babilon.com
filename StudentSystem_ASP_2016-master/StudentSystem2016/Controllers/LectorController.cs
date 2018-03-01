using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Lectures;
using System.Web.Mvc;
using System;
using DataAcsess.Enum;

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
        
        public override LectorEditVM PopulateModelToItem(Lecture entity, LectorEditVM model)
        {
            model.Name = entity.Name;
            model.LastName = entity.LastName;
            model.Email = entity.Email;
            model.Kabinet = entity.Kabinet.ToString();
            model.Mobile = entity.Mobile;
            return model;
        }

        public override Lecture PopulateItemToModel(LectorEditVM model, Lecture entity)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Kabinet = int.Parse(model.Kabinet);
            entity.Mobile = model.Mobile;
            return entity;
        }
        public override SingIn PopulateRegisterInfomationInModel(SingIn entity, LectorEditVM model)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.Email = model.Email;

            if (model.Role != Roles.Lector)
            {
                entity.Role = RoleAnotation(model.Role);
            }
            else
            {
                entity.Role = 3;
            }
            return entity;
        }
    }
}