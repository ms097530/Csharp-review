using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // * -------- ARRAYS --------

            // ? Arrays do not grow or shrink, uninitialized space will be some sort of default value

            string[] myGroceryArray = new string[2];
            myGroceryArray[0] = "Apples";
            myGroceryArray[1] = "Baguettes";
            Console.WriteLine(myGroceryArray);

            myGroceryArray.Append("Bonus Grocery");
            foreach (string grocery in myGroceryArray)
            {
                Console.WriteLine(grocery);
            }

            // initialize C# array
            int[] myIntArray = { 0, 1, 2 };

            int[] myEmptyArray = new int[3];

            myEmptyArray.Append(69);
            foreach (int num in myEmptyArray)
            {
                Console.WriteLine(num);
            }

            // * -------- LISTS --------

            List<int> myGroceryList = new List<int>(69);
            // number of items inside
            System.Console.WriteLine(myGroceryList.Count);
            // number of POSSIBLE items inside
            System.Console.WriteLine(myGroceryList.Capacity);

        }
    }
}
