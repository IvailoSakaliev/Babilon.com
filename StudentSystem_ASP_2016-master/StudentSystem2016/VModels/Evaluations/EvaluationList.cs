using DataAcsess.Models;
using System.Collections.Generic;

namespace StudentSystem2016.VModels.Evaluations
{
    public class EvaluationList
    {
        private List<Subject> _subject;
        private List<Evaluation> _evaluation;

        public EvaluationList()
        {
            _subject = new List<Subject>();
            _evaluation = new List<Evaluation>();
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string FacultetNumber { get; set; }
        public int Cours { get; set; }
        public int Group { get; set; }
        public string Specialty { get; set; }

        public List<Evaluation> Evaluations
        {
            get
            {
                return _evaluation;
            }
            set
            {
                _evaluation = value;
            }
        }
        public List<Subject> Subjects
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
    }
}