using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Students;
using System.Web.Mvc;
using System;

namespace StudentSystem2016.Controllers
{
    
    public class StudentController 
        : GenericController<Student, EditVM, StudentList, StudentFilter, StudentServise>
    {
        public StudentController()
            :base()
        {

        }

        public override Student PopulateItemToModel(EditVM model, Student entity)
        {
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.Course = int.Parse(model.Course);
            entity.Groups = int.Parse(model.Groups);
            entity.Inspector = model.Inspector;
            entity.OKS = model.OKS;
            entity.Inmage = model.Inmage;
            entity.Mobile = model.Mobile;
            return entity;
        }

        public override EditVM PopulateModelToItem(Student entity, EditVM model)
        {
            model.Name = entity.Name;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Course = entity.Course.ToString();
            model.Groups = entity.Groups.ToString();
            model.Inspector = entity.Inspector;
            model.OKS = entity.OKS;
            model.Inmage = entity.Inmage;
            model.Mobile = entity.Mobile;
            return model;
        }
    }
}