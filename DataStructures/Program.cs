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

            // create list of capacity 69 with 3 initialized elements
            List<int> myGroceryList = new List<int>() { 69, 28, 31, 11, 12 };
            // number of items inside
            System.Console.WriteLine(myGroceryList.Count);
            // number of POSSIBLE items inside
            System.Console.WriteLine(myGroceryList.Capacity);

            myGroceryList.Add(8008);

            // added element filled up empty space first
            Console.WriteLine(myGroceryList[5]);

            // * -------- IENUMERABLE --------

            // ? can not access element by index in IEnumerable
            // ? can not initialize IEnumerable on its own - use enumerable collection
            IEnumerable<int> myGroceryIEnumerable = myGroceryList;

            Console.WriteLine(myGroceryIEnumerable.First());
            Console.WriteLine(myGroceryIEnumerable.ToString());

            // * -------- 2D ARRAYS --------

            // initializing multi-dimensional array
            int[,] my2DArray = new int[,] {
                {1,2,3},
                {4,5,6}
            };
            // accessing element in multi-dimensional array
            Console.WriteLine(my2DArray[0, 2]);

            // * -------- DICTIONARY --------

            // initialize empty dictionary with string keys and int values
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            // map key of "hello" to value of 75
            myDictionary["hello"] = 75;
            Console.WriteLine(myDictionary["hello"]);

            // initialize dictionary with one value with key of "Dairy" with a value of a string array with values of 0: "Milk" and 1: "Cheese"
            Dictionary<string, string[]> myGroceryDictionary = new Dictionary<string, string[]>() {
                { "Dairy", new string[]{"Milk", "Cheese"} }
            };
            // set new key of "Meat" to an array with values 0: "Chicken" and 1: "Beef"
            myGroceryDictionary["Meat"] = new string[] { "Chicken", "Beef" };
            Console.WriteLine(myGroceryDictionary["Meat"][0]);
        }
    }
}
