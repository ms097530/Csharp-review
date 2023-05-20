using System;

namespace Methods
{
    internal class Program
    {
        // *  this variable is accessible in everything within Program - needs to be static to be accessible in static methods
        // ? this is a member variable
        static int ACCESSIBLE_INT = 69;

        // *  ! static methods can only access static attributes ! *
        static void Main(string[] args)
        {
            // Console.WriteLine(ACCESSIBLE_INT);
            // ? declaring this seems to completely invalidate even previous use of same-named variable
            // int ACCESSIBLE_INT = 420;

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