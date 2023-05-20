using System;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine(startTime);
            // pass in newly initialized anonymous array of ints
            Console.WriteLine(GetSum(new int[] { 1, 2, 3, 4, 5 }));

            Console.WriteLine(DateTime.Now - startTime);
        }

        // * static methods can only be called in static methods -- Main needs to be static, so make this static too
        static private int GetSum(int[] nums)
        {
            int total = 0;
            // foreach (int num in nums)
            // {
            //     total += num;
            // }
            for (int i = 0; i < nums.Length; ++i)
            {
                total += nums[i];
            }
            return total;
        }
    }
}