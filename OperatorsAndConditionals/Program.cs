using System;

namespace OperatorsAndConditionals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // * -------- MATH --------

            int myInt = 5;
            int mySecondInt = 10;

            Console.WriteLine(++myInt);
            Console.WriteLine(mySecondInt++);

            Console.WriteLine(--myInt);
            Console.WriteLine(mySecondInt--);

            Console.WriteLine(Math.Pow(myInt, 0.5));
            // without 'd' interprets 2nd arg as whole number division and returns 0 -> myInt ^ 0 = 1
            Console.WriteLine(Math.Pow(myInt, 1 / 2d));
            Console.WriteLine(Math.Sqrt(myInt));
            Console.WriteLine(Math.Exp(4));

            // * -------- PLAYING WITH STRINGS --------
            string myString = "TEST";

            myString += " dobbins";

            Console.WriteLine(myString);

            string[] myStringArr = myString.Split(" ");
            Console.WriteLine(myStringArr[0] + " AHHH " + myStringArr[1]);

            // * -------- COMPARISON OPERATORS --------
            // == Equality != Inequality
            // && AND || OR
            // > < >= <=
            Console.WriteLine(myInt != mySecondInt); // true
            Console.WriteLine(false && true); // false
            Console.WriteLine(false || true); // true
            Console.WriteLine(Convert.ToBoolean(myInt)); // true
            Console.WriteLine(Convert.ToBoolean(-1)); // false
            Console.WriteLine(Convert.ToBoolean(0)); // true
        }
    }
}
