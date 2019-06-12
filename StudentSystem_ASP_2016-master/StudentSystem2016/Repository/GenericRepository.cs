using StudentSystem2016.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;

namespace StudentSystem2016.Repository
{
    public abstract class GenericRepository<T> where T
         : BaseModel, new()
    {
        private OleDbConnection Connection = null;
        private bool IsInUofContext = false;
        protected abstract OleDbCommand GetSelectCommand(T item);
        protected abstract OleDbCommand GetUpdateCommand(T item);
        protected abstract OleDbCommand GetInsertCommand(T item);
        protected abstract OleDbCommand GetDeleteCommand(T item);
        protected abstract OleDbCommand GetDeleteIDCommand(T item);


        protected abstract void PopulateItem(T item, OleDbDataReader reader);

        public GenericRepository()
        {
            Connection = new OleDbConnection();
            Connection.ConnectionString = @"
Provider=SQLNCLI11; Server=localhost\SQLEXPRESS; Database=PhoneBookDB; Trusted_Connection=yes";
        }

        public GenericRepository(UnitOfWork uof)
        {
            Connection = uof.Connection;
        }

        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            OleDbCommand cmd = GetSelectCommand(null);
            cmd.Connection = Connection;

            OleDbDataReader reader = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T item = new T();

                    PopulateItem(item, reader);

                    result.Add(item);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (!IsInUofContext)
                    Connection.Close();
            }

            return result;
        }

        public T GetByID(int Id)
        {
            T result = null;

            OleDbCommand cmd = GetSelectCommand(null);
            cmd.Connection = Connection;

            OleDbDataReader reader = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new T();

                    PopulateItem(result, reader);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (!IsInUofContext)
                    Connection.Close();
            }

            return result;
        }

        public void Insert(T item)
        {
            OleDbCommand cmd = GetInsertCommand(item);
            cmd.Connection = Connection;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (!IsInUofContext)
                    Connection.Close();
            }
        }

        public void Update(T item)
        {
            OleDbCommand cmd = GetUpdateCommand(item);
            cmd.Connection = Connection;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (!IsInUofContext)
                    Connection.Close();
            }
        }

        public void Delete(T item)
        {
            OleDbCommand cmd = GetDeleteCommand(item);
            cmd.Connection = Connection;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (!IsInUofContext)
                    Connection.Close();
            }
        }
        public void Save(T item)
        {
            if (item.ID != null)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            }
        }
    }
}
