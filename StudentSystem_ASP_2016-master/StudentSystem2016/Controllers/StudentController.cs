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
            throw new NotImplementedException();
        }

        public override EditVM PopulateModelToItem(Student entity, EditVM model)
        {
            throw new NotImplementedException();
        }
    }
}