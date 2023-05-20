using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] myGroceryArray = new string[2];
            myGroceryArray[0] = "Apples";
            myGroceryArray[1] = "Baguettes";
            Console.WriteLine(myGroceryArray);

            myGroceryArray.Append("Bonus Grocery");
            foreach (string grocery in myGroceryArray)
            {
                Console.WriteLine(grocery);
            }
        }
    }
}
