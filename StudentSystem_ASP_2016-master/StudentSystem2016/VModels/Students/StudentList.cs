using StudentSystem2016.Filters.Entityfilters;
using DataAcsess.Models;

namespace StudentSystem2016.VModels.Students
{
    public class StudentList 
        :GenericList<Student, StudentFilter>
    {
        public StudentList()
            :base()
        {

        }
    }
}