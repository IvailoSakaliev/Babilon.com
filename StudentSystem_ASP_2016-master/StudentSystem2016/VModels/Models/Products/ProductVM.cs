﻿using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.VModels.Models.Products
{
    public class ProductVM
    {
        public ProductVM()
        {
            Image = new List<string>();
            ImageS = new List<Images>();
        }


        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Types { get; set; }

        [Required]
        public IEnumerable<SelectListItem> BaseType { get; set; }
        // next line of code is for edit pages

        public string FrontImage { get; set; }

        public int TypeString { get; set; }
        public int BaseTyoeString { get; set; }

        [Required]
        public string DateOfEdit { get; set; }

        public List<Images> ImageS { get; set; }

        [Display(Name = "Add new image")]
        public List<string> Image { get; set; }

    }
}