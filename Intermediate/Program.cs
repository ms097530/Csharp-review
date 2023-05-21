﻿using System.Data;
using System;
using Intermediate.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Intermediate.Data;
using Microsoft.Extensions.Configuration;

namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {

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


        }
    }
}
