using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class BaseTypeRepository
        : GenericRepository<BaseType>
    {
        protected override OleDbCommand GetDeleteCommand(BaseType item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(BaseType item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(BaseType item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(BaseType item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(BaseType item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(BaseType item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}