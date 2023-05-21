using System.Data;
using System;
using Intermediate.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Intermediate.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            // string sql =
            //     @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('"
            //     + myComputer.Motherboard
            //     + "','" + myComputer.HasWifi
            //     + "','" + myComputer.HasLTE
            //     + "','" + myComputer.ReleaseDate
            //     + "','" + myComputer.Price
            //     + "','" + myComputer.VideoCard
            //     + "')";

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
            // * --- SYSTEM
            // * maps 1 to 1 by default, change naming policy
            // * i.e. default: in file property = motherboard, looks to map to model as motherboard (rather than Motherboard)
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // * try to deserialize JSON that got converted to string
            // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // * --- NEWTONSOFT
            // * basically same thing but with Newtonsoft JSON
            // * doesn't need options to do what we want
            IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computers != null)
            {
                foreach (Computer computer in computers)
                {
                    // * outputting blanks for Motherboard because deserializer isn't returning Pascal-casing by default, it is trying to map 1 to 1
                    // Console.WriteLine(computer.Motherboard);

                    // * use loop to run an insert command for each computer
                    string sql = @"INSERT INTO TutorialAppSchema.Computer (
                        Motherboard,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES ('" + computer.Motherboard
                        + "','" + computer.HasWifi
                        + "','" + computer.HasLTE
                        + "','" + computer.ReleaseDate
                        + "','" + computer.Price
                        + "','" + computer.VideoCard
                        + "')";

                    dapper.ExecuteSql(sql);
                }
            }
            // * --- SYSTEM
            // * create copy and write to file using System
            // * can reuse options from above to serialize back to camelcase
            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computers, options);
            File.WriteAllText("computersCopySystem.txt", computersCopySystem);

            // * --- NEWTONSOFT
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            // * create copy and write to file using Newtonsoft
            // * without settings, will not be serialized back to camelcase
            string computersCopy = JsonConvert.SerializeObject(computers, settings);
            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopy);
        }
    }
}
