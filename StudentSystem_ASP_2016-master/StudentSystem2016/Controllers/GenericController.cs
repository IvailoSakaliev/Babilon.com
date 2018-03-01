using BissnessLogic.Sercises;
using DataAcsess.Models;
using StudentSystem2016.Filters;
using StudentSystem2016.VModels;
using System.Web.Mvc;
using System;
using DataAcsess.Enum;

namespace StudentSystem2016.Controllers
{
    public abstract  class GenericController<TEntity, TeidtVM, TlistVM, Tfilter, Tservise> : Controller
        where TEntity : BaseModel, new()
        where TeidtVM :  new()
        where Tfilter: GenericFiler<TEntity> , new()
        where TlistVM : GenericList<TEntity, Tfilter>, new()
        where Tservise: BaseServise<TEntity> , new()
    

    {
        public abstract TEntity PopulateItemToModel(TeidtVM model, TEntity entity);
        public abstract TeidtVM PopulateModelToItem(TEntity entity, TeidtVM model);
        public virtual SingIn PopulateRegisterInfomationInModel(SingIn entity, TeidtVM model)
        {
            throw new NullReferenceException();
        }

        public Tservise Servise { get; set; }
        public TEntity entity { get; set; }

        public GenericController()
        {
            this.Servise = new Tservise();
        }

        public ActionResult Index()
        {
            TlistVM itemVM = new TlistVM();
            itemVM.Filter = new Tfilter();
            PopulateIndex(itemVM);
            return View(itemVM.Items);
        }

        protected virtual void PopulateIndex(TlistVM itemVM)
        {
            string controllerName = GerControlerName();
            string actionname = GetActionName();

            itemVM.Pager.Controler = controllerName;
            itemVM.Pager.Action = actionname;

            itemVM.Items = Servise.GetAll(itemVM.Filter.BildFilter(), itemVM.Pager.CurrentPage, 10);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            TEntity entity = new TEntity();
            TeidtVM model = new TeidtVM();
            Tservise servise = new Tservise();
            entity = servise.GetByID(id);
            model = PopulateModelToItem(entity, model);
            servise.DeleteById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TeidtVM model)
        {
            TEntity entity = new TEntity();
            Tservise servise = new Tservise();
            entity = PopulateItemToModel(model, entity);
            servise.Save(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            TeidtVM model = new TeidtVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TeidtVM model)
        {
            TEntity entity = new TEntity();
            entity = PopulateItemToModel(model,entity);
            Tservise servise = new Tservise();
            servise.Save(entity);
            string nameOfModel = entity.GetType().Name;
            if (nameOfModel == "Lecture" || nameOfModel == "Student")
            {
                try
                {
                    SingIn register = new SingIn();
                    register = PopulateRegisterInfomationInModel(register, model);
                    SingInServise registerService = new SingInServise();
                    registerService.Save(register);
                }
                catch (NullReferenceException)
                {
                    Add(model);
                }
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TEntity entity = new TEntity();
            TeidtVM model = new TeidtVM();
            entity = Servise.GetByID(id);
            model = PopulateModelToItem(entity, model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Servise.DeleteById(id);
            return RedirectToAction("Index");
        }
        protected int RoleAnotation(Roles role)
        {
            switch (role)
            {
                case Roles.Student:
                    return 2;
                    break;
                case Roles.Lector:
                    return 3;
                    break;
                case Roles.Admin:
                    return 1;
                    break;
                default:
                    break;
            }
            return 0;
        }
    }
}