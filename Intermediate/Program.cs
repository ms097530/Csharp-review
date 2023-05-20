using System;

namespace Intermediate
{
    public class Computer
    {
        // best practice to make fields is to do the following:
        // field
        // private string _motherboard;
        // field accessed and manipulated by property
        // private string Motherboard {get {return _motherboard;} set {_motherboard = value;}}
        // * OR have shortcut of this:
        public string Motherboard { get; set; }
        public string VideoCard { get; set; }
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }

        // needs to be public to access
        public Computer()
        {
            if (VideoCard == null)
            {
                VideoCard = "";
            }
            if (Motherboard == null)
            {
                Motherboard = "";
            }
        }

        // ! BELOW ARE PUBLIC FIELDS - these go against best practice
        // public string Motherboard;
        // public string VideoCard;
        // public int CPUCores;
        // public bool HasWifi, HasLTE;
        // public DateTime ReleaseDate;
        // public decimal Price;
    }

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

            Console.WriteLine(myComputer.Motherboard);

            Console.WriteLine("end of file");
        }
    }
}
