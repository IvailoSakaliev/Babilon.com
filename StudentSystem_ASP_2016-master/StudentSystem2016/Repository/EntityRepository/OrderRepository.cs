using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class OrderRepository
        : GenericRepository<Order>
    {
        protected override OleDbCommand GetDeleteCommand(Order item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Order item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Order item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Order item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(Order item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Order item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}