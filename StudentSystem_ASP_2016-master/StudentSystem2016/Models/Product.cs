﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem2016.Models
{
    public class Product
        : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public int Basetype { get; set; }
        public int Type { get; set; }
        public int Front { get; set; }
    }
}
