using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Intermediate.Data
{
    public class DataContextDapper
    {
        // private IConfiguration _config;
        // * added ? and ="" to get rid of warning about possible null reference assignment - differs from provided code
        private string? _connectionString = "";
        // set configuration to be the same as passed in configuration
        public DataContextDapper(IConfiguration config)
        {
            // _config = config;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        // TrustServerCertificate is true for local machine because we can't get actual certificate but we can trust it

        public IEnumerable<T> LoadData<T>(string sql)
        {
            // IDbConnection from System.Data
            // SqlConnection from Microsoft.Data.SqlClient
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            // IDbConnection from System.Data
            // SqlConnection from Microsoft.Data.SqlClient
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            // IDbConnection from System.Data
            // SqlConnection from Microsoft.Data.SqlClient
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            // IDbConnection from System.Data
            // SqlConnection from Microsoft.Data.SqlClient
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }
}