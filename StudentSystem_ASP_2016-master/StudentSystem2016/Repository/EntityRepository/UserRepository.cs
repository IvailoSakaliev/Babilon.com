using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class UserRepository
        : GenericRepository<User>
    {
        protected override OleDbCommand GetDeleteCommand(User item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(User item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(User item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(User item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(User item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(User item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}