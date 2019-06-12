using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class TypeRepository
        : GenericRepository<TypeSubject>
    {
        protected override OleDbCommand GetDeleteCommand(TypeSubject item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(TypeSubject item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(TypeSubject item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(TypeSubject item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetUpdateCommand(TypeSubject item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(TypeSubject item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}