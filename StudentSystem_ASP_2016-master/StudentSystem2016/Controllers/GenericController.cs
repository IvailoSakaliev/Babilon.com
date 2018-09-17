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
using SS.SpecialtyServise;
using System.Collections.Generic;
using SS.FacultelServise;

namespace StudentSystem2016.Controllers
{
    public abstract class GenericController<TEntity, TeidtVM, TlistVM, Tfilter, Tservise> : Controller
        where TEntity : BaseModel, new()
        where TeidtVM : new()
        where Tfilter : GenericFiler<TEntity>, new()
        where TlistVM : GenericList<TEntity, Tfilter>, new()
        where Tservise : BaseServise<TEntity>, new()
    {

        public Tservise _Servise { get; set; }
        public TEntity entity { get; set; }
        protected int login_id { get; set; }
        private SingInServises _singin { get; set; }

        public GenericController()
        {
            _Servise = new Tservise();
            _singin = new SingInServises();
        }

        [AuthenticationFilter]
        public ActionResult Index(int Curentpage)
        {
            TlistVM itemVM = new TlistVM();
            itemVM.Filter = new Tfilter();
            itemVM = PopulateIndex(itemVM, Curentpage);
            return View(itemVM);
        }

        protected virtual TlistVM PopulateIndex(TlistVM itemVM, int curentPage)
        {
            string controllerName = GetControlerName();
            string actionname = GetActionName();

            itemVM.ControllerName = controllerName;
            itemVM.ActionName = actionname;
            itemVM.AllItems = _Servise.GetAll();
            itemVM.Pages = itemVM.AllItems.Count / 10;
            double doublePages = itemVM.AllItems.Count / 10.0;
            if (doublePages > itemVM.Pages)
            {
                itemVM.Pages++;
            }
            itemVM.StartItem = 10 * curentPage;
            try
            {
                for (int i = itemVM.StartItem - 10; i < itemVM.StartItem; i++)
                {
                    itemVM.Items.Add(itemVM.AllItems[i]);
                }
            }
            catch (Exception)
            {

            }

            return itemVM;
        }

        private string GetActionName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }

        private string GetControlerName()
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
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TeidtVM model, int id)
        {
            if (ModelState.IsValid == true)
            {
                TEntity entity = new TEntity();
                Tservise servise = new Tservise();
                entity = PopulateEditItemToModel(model, entity, id);
                servise.Save(entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [AuthenticationFilter]
        public ActionResult Add()
        {
            TeidtVM model = new TeidtVM();
            string nameOfController = GetControlerName();
            try
            {
                if (nameOfController == "Subject")
                {
                    return RedirectToAction("AddSubject");
                }
                if (nameOfController == "Student")
                {
                    model = PopilateSelectListIthem(model);

                }
            }
            catch (NullReferenceException)
            {

                throw;
            }
            return View(model);
        }



        [HttpPost]
        public ActionResult Add(TeidtVM model)
        {
            if (!ModelState.IsValid)
            {
                TEntity entity = new TEntity();
                string nameOfModel = entity.GetType().Name;
                if (nameOfModel == "Lecture" || nameOfModel == "Student")
                {
                    SingInServises registerService = new SingInServises();
                    AuthenticationServises authenticate = new AuthenticationServises();
                    try
                    {
                        if (CheckForExitedUserInDB(model))
                        {

                            SingIn register = new SingIn();
                            register = PopulateRegisterInfomationInModel(register, model);
                            if (register != null)
                            {
                                registerService.Save(register);
                            }
                            else
                            {
                                return View(model);
                            }
                            authenticate.AuthenticateUser(_singin.EncriptServise.DencryptData(register.Username), _singin.EncriptServise.DencryptData(register.Password), 2);
                            this.login_id = authenticate.Login_id;
                            AddInformation(entity, model);
                            if (nameOfModel == "Student")
                            {
                                EmailServises email = new EmailServises(register);
                                //email.SendEmail(1);
                                return RedirectToAction("GoToConfirm");
                            }
                        }

                    }
                    catch (NullReferenceException)
                    {
                        Add(model);
                    }

                }
                AddInformation(entity, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void AddInformation(TEntity entity, TeidtVM model)
        {
            entity = PopulateItemToModel(model, entity);
            Tservise servise = new Tservise();
            servise.Save(entity);
        }

        [HttpGet]
        [AuthenticationFilter]
        public ActionResult Details(int id)
        {
            TEntity entity = new TEntity();
            TeidtVM model = new TeidtVM();
            entity = _Servise.GetByID(id);
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
            _Servise.DeleteById(id);
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
        public abstract TEntity PopulateEditItemToModel(TeidtVM model, TEntity entity, int id);
        public virtual TeidtVM PopilateSelectListIthem(TeidtVM model)
        {
            throw new NullReferenceException();
        }
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