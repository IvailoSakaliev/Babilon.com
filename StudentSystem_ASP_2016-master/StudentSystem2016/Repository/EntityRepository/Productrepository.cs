using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class Productrepository
        : GenericRepository<Product>
    {
        protected override OleDbCommand GetDeleteCommand(Product item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Product item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Product item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Product item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(Product item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Product item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}