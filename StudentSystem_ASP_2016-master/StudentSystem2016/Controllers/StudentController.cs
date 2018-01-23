using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters.Entityfilters;
using StudentSystem2016.VModels.Students;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    
    public class StudentController 
        : GenericController<Student, EditVM, StudentList, StudentFilter, StudentServise>
    {
        public StudentController()
            :base()
        {

        }
        
        [HttpGet]
        public ActionResult Registration()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Registration(EditVM model)
        {
            StudentServise servise = new StudentServise();
            Student student = new Student();
            student.Name = model.Name;
            student.LastName = model.LastName;
            student.Email = model.Email;
            student.Username = model.EGN;
            student.Password = model.Password;
            student.Course = int.Parse(model.Course);
            student.Groups = int.Parse(model.Groups);
            student.Inspector = model.Inspector;
            student.OKS = model.OKS;
            student.Inmage = model.Inmage;
            student.Mobile = model.Mobile;

            servise.Save(student);

            LectureServise registre = new LectureServise();
            SingIn registrateUser = new SingIn();
            registrateUser.UserName = student.Username;
            registrateUser.Password = student.Password;
            registrateUser.Employeee = 1;

            registre.Save(registrateUser);
            
            return View(model);
        }
    }
}