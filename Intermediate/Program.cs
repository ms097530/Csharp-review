using System.Data;
using System;
using Intermediate.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Intermediate.Data;

namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();

            string sqlCommand = "SELECT GETDATE()";

            // Query from Dapper
            // Query will return array of results
            // QuerySingle returns one result
            // DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

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

            string sql =
                @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('"
                + myComputer.Motherboard
                + "','" + myComputer.HasWifi
                + "','" + myComputer.HasLTE
                + "','" + myComputer.ReleaseDate
                + "','" + myComputer.Price
                + "','" + myComputer.VideoCard
                + "')";

            // returns whether the executed sql affected anything
            bool result = dapper.ExecuteSql(sql);

            Console.WriteLine(result);

            string sqlSelect = @"SELECT 
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
             FROM TutorialAppSchema.Computer";

            // returns IEnumerable of type we used
            // could convert to List by adding ToList() method at the end
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach (Computer computer in computers)
            {
                Console.WriteLine("'"
                + computer.Motherboard
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleaseDate
                + "','" + computer.Price
                + "','" + computer.VideoCard
                + "')");
            }

            // Console.WriteLine(myComputer.Motherboard);

            // Console.WriteLine("end of file");
        }
    }
}
