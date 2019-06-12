using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class ImagesRepository
        : GenericRepository<Images>
    {
        protected override OleDbCommand GetDeleteCommand(Images item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Images item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Images item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Images item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(Images item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Images item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}