using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Intermediate.Data
{
    public class DataContextDapper
    {
        // TrustServerCertificate is true for local machine because we can't get actual certificate but we can trust it
        private string _connectionString =
            "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

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