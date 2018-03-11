using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Subjects;
using SS.SubjectServise;

namespace StudentSystem2016.Controllers
{
    public class SubjectController 
        :GenericController<Subject, EditVM, SubjectList, SubjectFilter, SubjectServise> 
    {
       

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
    }
}