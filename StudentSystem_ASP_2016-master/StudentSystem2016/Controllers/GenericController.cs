using DataAcsess.Models;
using StudentSystem2016.Filters;
using StudentSystem2016.VModels;
using System.Web.Mvc;
using System;
using DataAcsess.Enum;
using StudentSystem2016.Authentication;
using SS.GenericServise;
using SS.AuthenticationServise;
using SS.SingInServise;
using SS.EmailServise;

namespace StudentSystem2016.Controllers
{
    public abstract  class GenericController<TEntity, TeidtVM, TlistVM, Tfilter, Tservise> : Controller
        where TEntity : BaseModel, new()
        where TeidtVM :  new()
        where Tfilter: GenericFiler<TEntity> , new()
        where TlistVM : GenericList<TEntity, Tfilter>, new()
        where Tservise: BaseServise<TEntity> , new()
    

    {
        
        public Tservise Servise { get; set; }
        public TEntity entity { get; set; }
        protected int login_id { get; set; }

        public GenericController()
        {
            this.Servise = new Tservise();
        }

        [AuthenticationFilter]
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
        [AuthenticationFilter]
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
        [AuthenticationFilter]
        public ActionResult Add(TeidtVM model)
        {
            TEntity entity = new TEntity();
            string nameOfModel = entity.GetType().Name;
            if (nameOfModel == "Lecture" || nameOfModel == "Student")
            {
                SingInServise registerService = new SingInServise();
                AuthenticationServise authenticate = new AuthenticationServise();
                try
                { 
                    if (!CheckForExitedUserInDB(model))
                    {
                        
                        SingIn register = new SingIn();
                        register = PopulateRegisterInfomationInModel(register, model);
                        registerService.Save(register);
                        authenticate.AuthenticateUser(register.Username , register.Password,2);
                        this.login_id = authenticate.Login_id;
                        EmailServise email = new EmailServise(register);
                        email.SendEmail();
                    }
                    
                }
                catch (NullReferenceException)
                {
                    Add(model);
                }
                
            }
            entity = PopulateItemToModel(model, entity);
            Tservise servise = new Tservise();
            servise.Save(entity);
            if (nameOfModel == "Student")
            {
                return RedirectToAction("GoToConfirm");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AuthenticationFilter]
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


        // abstract and viirtual classess 
        public abstract TEntity PopulateItemToModel(TeidtVM model, TEntity entity);
        public abstract TeidtVM PopulateModelToItem(TEntity entity, TeidtVM model);
        public virtual SingIn PopulateRegisterInfomationInModel(SingIn entity, TeidtVM model)
        {
            throw new NullReferenceException();
        }
        public virtual bool CheckForExitedUserInDB(TeidtVM model)
        {
            throw new NullReferenceException();
        }

    }
}