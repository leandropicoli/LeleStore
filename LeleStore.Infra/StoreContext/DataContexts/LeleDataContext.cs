using System;
using System.Data;
using System.Data.SqlClient;
using LeleStore.Shared;

namespace LeleStore.Infra.StoreContext.DataContexts
{
    public class LeleDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public LeleDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}