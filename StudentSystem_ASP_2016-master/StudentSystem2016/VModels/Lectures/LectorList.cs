using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;

namespace StudentSystem2016.VModels.Lectures
{
    public class LectorList
        : GenericList<Lecture, LectorFilter>
    {
        public LectorList()
            :base()
        {

        }
       
    }
}