using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Pager
{
    public class PagerVM
    {

        public string Prefix { get; set; }
        public string Action { get; set; }
        public string Controler { get; set; }
        public int TotalIthems { get; set; }
        public int CurrentPage { get; set; }
        private int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagerVM() 
            : this(0,1,"","","",10)
        {

        }

        public PagerVM(int totalIthams, int?page, string prefix, string action, string controler, int pageSize = 0)
        {
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var totalPagees =   (int) Math.Ceiling((decimal)totalIthams / (decimal)pageSize);
            var currentpage = page != null ? (int)page : 1;
            var startPage = currentpage - 5;
            var endPage = currentpage + 4;

            if (startPage > totalPagees)
            {
                endPage -= (startPage = 1);
                startPage = 1;
            }

            if (endPage > totalPagees)
            {
                endPage = totalPagees;
                if (endPage < 10)
                {
                    startPage = endPage = 9;
                }
            }

            TotalIthems = totalIthams;
            TotalPages = totalPagees;
            CurrentPage = currentpage;
            Controler = controler;
            Prefix = prefix;
            Action = action;
            StartPage = startPage;
            EndPage = endPage;

        }
    }
}