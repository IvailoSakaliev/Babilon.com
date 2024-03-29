﻿using StudentSystem2016.Models;
using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.Servises.EntityServise;
using StudentSystem2016.VModels.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystem2016.VModels.Models.Products;

namespace StudentSystem2016.Controllers
{
    public class TypeController
       : GenericController<TypeSubject, TypeVM, TypeList, TypeFilter, TypeServise>
    {
        private BaseTypeServise _baseServise = new BaseTypeServise();
        private static int _ItemID;

       
    
    public override TypeSubject PopulateEditItemToModel(TypeVM model, TypeSubject entity, int id)
        {
            entity.ID = id;
            entity.Name = model.Type;
            entity.BaseTypeID = int.Parse(Request.Form["basemodel"]);
            return entity;
        }

        public override TypeSubject PopulateItemToModel(TypeVM model, TypeSubject entity)
        {
            entity.Name = model.Type;
            int valueOfsection = int.Parse(Request.Form["basemodel"]);
            if (valueOfsection == -1)
            {
                ModelState.AddModelError(string.Empty, "Please select value of dropDownlist");
                return entity = null;
            }
            else
            {
                entity.BaseTypeID = valueOfsection;
            }

            return entity;
        }

        public override TypeVM PopulateModelToItem(TypeSubject entity, TypeVM model)
        {
            model.Type = entity.Name;
            var type = _baseServise.GetAll();
            GenericSelectedList<BaseType> listUser = new GenericSelectedList<BaseType>();
            model.ID = entity.BaseTypeID;
            model.BaseModel = listUser.GetSelectedListIthem(type);
            model.selectedItem = entity.BaseTypeID;
            return model;
        }
        public override TypeVM PopilateSelectListIthem(TypeVM model)
        {
            model.Type = "";
            var type = _baseServise.GetAll();
            GenericSelectedList<BaseType> listUser = new GenericSelectedList<BaseType>();

            model.BaseModel = listUser.GetSelectedListIthem(type);

            return model;
        }

        internal override string PopulateINdexType(TypeList itemVM, int id, int _curentPage)
        {
            string items = "";
            if (id > 11)
            {
                id -= (12 * (_curentPage - 1));
            }
            var element = _baseServise.GetByID(itemVM.Items[id].BaseTypeID);
            items = element.Name;
            return items;
        }
    }
}