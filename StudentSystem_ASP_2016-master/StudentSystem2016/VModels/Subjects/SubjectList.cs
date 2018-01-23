using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;

namespace StudentSystem2016.VModels.Subjects
{
    public class SubjectList
        :GenericList<Subject, SubjectFilter>
    {
    }
}