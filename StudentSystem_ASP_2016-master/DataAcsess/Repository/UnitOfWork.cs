using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Repository
{
    public class UnitOfWork
    {
        internal OleDbConnection Connection { get; private set; }
        private OleDbTransaction Transaction = null;

        public UnitOfWork()
        {
            Connection = new OleDbConnection();
            Connection.ConnectionString = @"Data Source=(local);Initial Catalog=vavilonci_;User ID=vavilonci;Password=Edzh826@";

        }

        public void Start()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null;
            }
        }
    }
}
