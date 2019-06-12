using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class ContactRepository
        : GenericRepository<Contact>
    {
        protected override OleDbCommand GetDeleteCommand(Contact item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Contact item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Contact item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Contact item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(Contact item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Contact item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}