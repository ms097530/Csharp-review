using System.Data;
using System;
using Intermediate.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Intermediate.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

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

            // write SQL command to file
            // ? If file already exists, what will happen?
            // * File gets overwritten by default
            // File.WriteAllText("log.txt", sql);

            // using StreamWriter openFile = new("log.txt", append: true);

            // openFile.WriteLine(sql + "\n");

            // // can't read unless writing is done
            // openFile.Close();

            // string fileText = File.ReadAllText("log.txt");

            // Console.WriteLine(fileText);

            // * stored in string as is, can't access key-value pairs or access like model
            string computersJson = File.ReadAllText("Computers.json");

            // Console.WriteLine(computersJson);

            // * maps 1 to 1 by default, change naming policy
            // * i.e. default: in file property = motherboard, looks to map to model as motherboard (rather than Motherboard)
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // * try to deserialize JSON that got converted to string
            IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            if (computers != null)
            {
                foreach (Computer computer in computers)
                {
                    // outputting blanks for Motherboard because deserializer isn't returning Pascal-casing by default, it is trying to map 1 to 1
                    Console.WriteLine(computer.Motherboard);
                }
            }
        }
    }
}
