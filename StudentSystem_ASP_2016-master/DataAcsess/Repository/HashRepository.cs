using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Repository
{
    public class HashRepository
        : GenericRepository<Hash>
    {
        protected override OleDbCommand GetDeleteCommand(Hash item)
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
 Hashes;
";

            return cmd;
        }

        protected override OleDbCommand GetUpdateCommand(Hash item)
        {
            throw new NotImplementedException();
        }

    }
}
