using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters;
using StudentSystem2016.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public abstract class GenericController<TEntity, TeidtVM, TlistVM, Tfilter, TServise> : Controller
        where TEntity : BaseModel, new()
        where TeidtVM :  EditPersoneVM, new()
        where Tfilter: GenericFiler<TEntity> , new()
        where TlistVM : GenericList<TEntity, Tfilter>, new()
        where TServise : BaseServise<TEntity>, new()
    {
        
        public TServise Servise { get; set; }

        public GenericController()
        {
            this.Servise = new TServise();
        }
        public ActionResult Index()
        {
            TlistVM itemVM = new TlistVM();
            itemVM.Filter = new Tfilter();
            PopulateIndex(itemVM);
            return View();
        }

        private void PopulateIndex(TlistVM itemVM)
        {
            string controllerName = GerControlerName();
            string actionname = GetActionName();

            itemVM.Pager.Controler = controllerName;
            itemVM.Pager.Action = actionname;

            itemVM.Iteams = this.Servise.GetAll(itemVM.Filter.BildFilter(), itemVM.Pager.CurrentPage, 10);
            itemVM.Filter.Pager = itemVM.Pager;
            itemVM.Pager.Prefix = "Pager.";
            itemVM.Filter.Prefix = "Filter.";

        }

        private string GetActionName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }

        private string GerControlerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }

    }
}