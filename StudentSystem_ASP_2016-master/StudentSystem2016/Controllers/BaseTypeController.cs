using StudentSystem2016.Models;
using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.Servises.EntityServise;
using StudentSystem2016.VModels.Models.BaseTypes;
using System;

namespace StudentSystem2016.Controllers
{
    public class BaseTypeController
        : GenericController<BaseType, BaseTypeEditVm, BaseTypeList, BaseTypeFilter, BaseTypeServise>
    {
        public override BaseType PopulateEditItemToModel(BaseTypeEditVm model, BaseType entity, int id)
        {
            entity.ID = id;
            entity.Name = model.Name;
            return entity;
        }

        public override BaseType PopulateItemToModel(BaseTypeEditVm model, BaseType entity)
        {
            entity.Name = model.Name;
            return entity;
        }

        public override BaseTypeEditVm PopulateModelToItem(BaseType entity, BaseTypeEditVm model)
        {
            model.Name = entity.Name;
            return model;
        }

        internal override string PopulateINdexType(BaseTypeList itemVM, int id, int curentpage)
        {
            throw new NotImplementedException();
        }
    }
}