using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAcsess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContextTransaction transaction;
        public StudentDBContext context { get; private set; }

        public UnitOfWork()
            :this(new StudentDBContext())
        {
            this.context = new StudentDBContext();
        }

        public UnitOfWork(StudentDBContext data)
        {
            this.context = data;
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
            else
            {
                Dispose();
            }
        }

        public void Rowback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
            else
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            transaction.Dispose();
            this.context.Dispose();
        }

    }
}
