﻿using System.Data;
using System;
using Intermediate.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TrustServerCertificate is true for local machine because we can't get actual certificate but we can trust it
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            // IDbConnection from System.Data
            // SqlConnection from Microsoft.Data.SqlClient
            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            // Query from Dapper
            // Query will return array of results
            // QuerySingle returns one result
            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            Console.WriteLine(myComputer.Motherboard);

            Console.WriteLine("end of file");
        }
    }
}
