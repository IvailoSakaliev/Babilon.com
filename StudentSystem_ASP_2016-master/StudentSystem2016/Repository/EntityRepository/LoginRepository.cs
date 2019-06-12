using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class LoginRepository
        : GenericRepository<Login>
    {
        protected override OleDbCommand GetDeleteCommand(Login item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Login item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Login item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Login item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(Login item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Login item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}