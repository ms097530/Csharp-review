// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("test");
// Console.Write("AHHHHH\n");

// * can still access args despite it not being visible anywhere in the file (due to template hiding some of what's going on)
// Console.WriteLine(args[0]);

// * This is what old template looks like and is more typical in C# programs
using System;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // * -------- WHOLE NUMBERS --------

            // signed byte
            sbyte minSbyte = -128;
            sbyte maxSbyte = 127;
            // unsigned byte
            byte minByte = 0;
            byte maxByte = Byte.MaxValue;

            Console.WriteLine(minSbyte);
            Console.WriteLine(maxSbyte);
            Console.WriteLine(minByte);
            Console.WriteLine(maxByte);

            // short is alias for Int16
            short minShort = Int16.MinValue;
            short maxShort = short.MaxValue;

            ushort minUshort = UInt16.MinValue;
            ushort maxUshort = ushort.MaxValue;

            Console.WriteLine(minShort);
            Console.WriteLine(maxShort);

            Console.WriteLine(minUshort);
            Console.WriteLine(maxUshort);

            int minInt = Int32.MinValue;
            int maxInt = int.MaxValue;

            // -2147483648 to 2147483647
            Console.WriteLine(minInt);
            Console.WriteLine(maxInt);

            // LONG min and max
            Console.WriteLine(long.MinValue);
            Console.WriteLine(Int64.MaxValue);

            // * ----------- FLOATING POINT NUMBERS ------------

            // ? FLOAT takes up least space, then DOUBLE, then DECIMAL
            // ? however, smaller types can have issues with accuracy that may not be acceptable

            // ! throws error without 'f' on end (assumes it is double and can not convert implicitly)
            float myFloat = 0.751f;
            float mySecondFloat = 0.75f;

            // implicit double
            double myDouble = 0.751;
            // explicit double
            double mySecondDouble = 0.75d;

            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.75m;

            // 0.0009999871
            Console.WriteLine(myFloat - mySecondFloat);
            // 0.0010000000000000009
            Console.WriteLine(myDouble - mySecondDouble);
            // 0.001
            Console.WriteLine(myDecimal - mySecondDecimal);

            // * ----------- STRING -----------
            string myString = "A STRING";

            // template string
            Console.WriteLine($"{myString}");


            // * ----------- BOOLEAN -----------
            bool myBoolean = true;
            Console.WriteLine(myBoolean);

        }
    }
}