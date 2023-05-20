using System;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetSum();
        }

        // * static methods can only be called in static methods -- Main needs to be static, so make this static too
        static private int GetSum()
        {
            Console.WriteLine("Hello");
            return 69;
        }
    }
}