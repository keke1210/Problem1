using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    class Program
    {
        // Solution with LINQ -> Time complexity O(n^2)
        static void alg1(string haystack, string needle, int threshold)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Gets all posible strings from a string with the length >= threshold
            var allSubstrings =
             from i in Enumerable.Range(0, needle.Length)
             from j in Enumerable.Range(0, needle.Length - i + 1)
             where j >= threshold
             select needle.Substring(i, j);

            foreach (var str in allSubstrings)
            {
                //Console.WriteLine(str);
                if (haystack.IndexOf(str) != -1 && needle.IndexOf(str) != -1)
                    Console.WriteLine($"sequence of length = {str.Length} found at haystack offset {haystack.IndexOf(str)}, needle offset {needle.IndexOf(str)}");
            }


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }



        // Time complexity O(n^2)
        static void alg2(string haystack, string needle, int threshold)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (threshold > needle.Length) return;


            for (int start = 0; start < needle.Length ; start++)
            {

                for(int end = 0; end< needle.Length - start + 1; end++)
                {
                    if(end >= threshold)
                    {
                        // tgjitha sekuencat >= threashhold
                        var allSubstrings = needle.Substring(start, end);

                        var test = haystack.IndexOf(allSubstrings);
                        var needleOffset = needle.IndexOf(allSubstrings);

                        if (test != -1 && needleOffset != -1) //Console.WriteLine(allSubstrings);
                            Console.WriteLine($"sequence of length = {end} found at haystack offset {test}, needle offset {needleOffset}");
                    }
                }
            }


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }




        // The optimal solution would be with Window Sliding Technique Algorithm??  Knuth–Morris–Pratt (KMP) algorithm?? 
        static void alg3(string haystack, string needle, int threshold)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (threshold > needle.Length) return;

            int n = haystack.Length, m = needle.Length;

           
            // Not Implemented


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }


        static void Main(string[] args)
        {

            string haystack = "vnk2435kvabco8awkh125kjneytbcd12qjhb4acd123xmnbqwnw4t";
            string needle = "abcd1234";
            int threshold = 3;


            //alg1(haystack, needle, threshold);
            alg2(haystack, needle, threshold);
            //alg3(haystack, needle, threshold);

            Console.ReadKey();
        }
    }
}
