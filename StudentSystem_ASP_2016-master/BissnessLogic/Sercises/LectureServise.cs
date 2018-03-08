using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BissnessLogic.Sercises
{
    public class LectureServise: BaseServise<Lecture>
    {
        public LectureServise()
            :base()
        {

        }
        public LectureServise(UnitOfWork unit)
            : base(unit)
        {

        }

        public Lecture GetByloginID(int id)
        {
            Lecture lector = new Lecture();
            int login_id = id;
            List<Lecture> list = repo.GetAll((u) => u.Login == login_id).ToList();
            lector = list.Count > 0 ? list[0] : null;
            return lector;
        }

    }
}
