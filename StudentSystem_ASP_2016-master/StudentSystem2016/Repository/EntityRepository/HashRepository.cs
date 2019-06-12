using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Repository.EntityRepository
{
    public class HashRepository
        : GenericRepository<Hash>
    {
        protected override OleDbCommand GetDeleteCommand(Hash item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetDeleteIDCommand(Hash item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetInsertCommand(Hash item)
        {
            throw new NotImplementedException();
        }

        protected override OleDbCommand GetSelectCommand(Hash item)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"
SELECT
 *
FROM
 Hashes
";

            return cmd;
        }

        protected override OleDbCommand GetUpdateCommand(Hash item)
        {
            throw new NotImplementedException();
        }

        protected override void PopulateItem(Hash item, OleDbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}