using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, string> userAges = new SortedDictionary<int, string>();
            userAges[31] = "Gosho";
            userAges[51] = "Iwan";
            userAges[41] = "Pepi";
            userAges[21] = "Pesho";
            foreach (var item in userAges)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }



            //    Dictionary<int, string> students = new Dictionary<int, string>();
            //    List<int> numbers = new List<int>();
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        numbers.Add(i);
            //        students.Add(i, i.ToString());
            //    }
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        numbers.Contains(i);
            //    }
            //    watch.Stop();
            //    Console.WriteLine(watch.ElapsedMilliseconds);
            //    watch.Reset();
            //    watch.Start();
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        students.ContainsKey(i);
            //    }
            //    watch.Stop();
            //    Console.WriteLine(watch.ElapsedMilliseconds);


            //Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>()
            //{
            //    {"Kompot", 24 },
            //    {"Banana", 32 }
            //};

            //productPrices["Kiwi"] = 100;
            //productPrices["apple"] = 1;
            //Console.WriteLine(productPrices["Kiwi"]);
            //Console.WriteLine(productPrices["apple"]);
            //Console.WriteLine(productPrices["Kompot"]);
            //Console.WriteLine(productPrices["Banana"]);
            ////  Console.WriteLine(productPrices["not found product"]);
            //// Console.WriteLine(string.Join(",", productPrices));
            //string key = "orange";
            //Console.WriteLine($"Contains key {key} -> {productPrices.ContainsKey(key)}");
            // key = "apple";
            //Console.WriteLine($"Contains key {key} -> {productPrices.ContainsKey(key)}");
            // key = "Banana";
            //Console.WriteLine($"Contains key {key} -> {productPrices.ContainsKey(key)}");
            // key = "notvalid";
            //Console.WriteLine($"Contains key {key} -> {productPrices.ContainsKey(key)}");

            //Dictionary<int, List<string>> studentGrades = new Dictionary<int, List<string>>();

            //studentGrades.Add(2, new List<string>());
            //studentGrades[2].Add("Pesho");
            //studentGrades[2].Add("Gosho");
            //studentGrades[2].Add("Dimi");
            //studentGrades.Add(1, new List<string>());
            //studentGrades[1].Add("Sashko");
            //Console.WriteLine(studentGrades[2][0]);
            //Console.WriteLine(studentGrades[2][1]);
            //Console.WriteLine(studentGrades[2][2]);
            //Console.WriteLine(studentGrades[1][0]);
        }
    }
}
