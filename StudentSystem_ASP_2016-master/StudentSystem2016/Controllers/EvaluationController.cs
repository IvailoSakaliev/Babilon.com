using DataAcsess.Models;
using SS.EvaluationServise;
using SS.SpecialtyServise;
using SS.SpecialtySubjectServise;
using SS.StudentServise;
using SS.SubjectServise;
using StudentSystem2016.Authentication;
using StudentSystem2016.VModels.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class EvaluationController : Controller
    {
        StudentServises student = new StudentServises();
        SpecialtyServises specialty = new SpecialtyServises();
        SubjectServises subject = new SubjectServises();
        EvaluationServise evaluation = new EvaluationServise();
        SpecialtySubjectServises specialtySubject = new SpecialtySubjectServises();

        [AuthenticationFilter]
        public ActionResult Index(int id)
        {
            EvaluationList model = new EvaluationList();
            model = PopulateInformation(model, id);
            return View(model);
        }

        private EvaluationList PopulateInformation(EvaluationList model, int id)
        {
            var studentInfo = student.GetByID(id);
            var specialtyInfo = specialty.GetByID(studentInfo.Specialties);
            var subjectIdFromStudentSpecialty = specialtySubject.GetAll().Where(m => m.SpecialtyID == studentInfo.Specialties);
            var evaluationListForUser = evaluation.GetAll().Where(m => m.StudentID == studentInfo.ID);

            foreach (var item in subjectIdFromStudentSpecialty)
            {
                model.Subjects.Add(subject.GetByID(item.SubjectID));
            }

            foreach (var subjectItem in model.Subjects)
            {
                foreach (var evaluationItem in evaluationListForUser)
                {
                    if (evaluationItem.SubjectID == subjectItem.ID)
                    {
                        model.Evaluations.Add(evaluationItem);
                    }
                }
            }

            model.Name = studentInfo.Name;
            model.LastName = studentInfo.LastName;
            model.Group = studentInfo.Groups;
            model.Cours = studentInfo.Course;
            model.Specialty = specialtyInfo.Name;

            return model;
        }


        [HttpGet]
        [AuthenticationFilter]
        public ActionResult Add(int id)
        {
            AddEvaluation model = new AddEvaluation();
            model = PopulateSelectListIthem(model, id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEvaluation model, int id)
        {
            if (CheckForExitingEvaluationInDB(model,id))
            {
                Evaluation entity = new Evaluation();
                entity = PopulateIthemInEntity(entity, model, id);
                evaluation.Save(entity);
                //messege for error
            }
            return RedirectToAction("Index", "Student", "");

        }

        private bool CheckForExitingEvaluationInDB(AddEvaluation model, int id)
        {
            var studentInfo = student.GetByID(id);
            int subjectID = int.Parse(Request.Form["subjects"].ToString());
            var result = evaluation.GetAll().Where(m => m.StudentID == studentInfo.ID );
            foreach (var item in result)
            {
                if (item.SubjectID == subjectID)
                {
                    return false;
                }
            }
            return true;
        }

        private Evaluation PopulateIthemInEntity(Evaluation entity, AddEvaluation model, int id)
        {
            entity.SubjectID = int.Parse(Request.Form["subjects"].ToString());
            entity.StudentID = id;
            entity.Ocenka = model.Evaluation;

            return entity;
        }

        private IEnumerable<SelectListItem> GetSelectedListIthem(List<Subject> result)
        {
            var selectedList = new List<SelectListItem>();
            for (int i = 0; i < result.Count; i++)
            {
                selectedList.Add(new SelectListItem
                {
                    Value = result[i].ID.ToString(),
                    Text = result[i].Name.ToString()
                });
            }

            return selectedList;
        }

        public AddEvaluation PopulateSelectListIthem(AddEvaluation model, int id)
        {
            
            var studentInfo = student.GetByID(id);
            var subjectIdFromStudentSpecialty = specialtySubject.GetAll().Where(m => m.SpecialtyID == studentInfo.Specialties);
            List<Subject> result = new List<Subject>();

            foreach (var item in subjectIdFromStudentSpecialty)
            {
                result.Add(subject.GetByID(item.SubjectID));
            }
            model.Subjects = GetSelectedListIthem(result);
            model.StudentID = id;
            return model;
        }

    }
}