using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace StudentSystem2016.VModels.Evaluations
{
	public class AddEvaluation
	{
        public int StudentID { get; set; }
        [Required]
        public IEnumerable<SelectListItem> Subjects { get; set; }

		[Required]
        [Range(2,6)]
        public int Evaluation{ get; set; }
    }
}