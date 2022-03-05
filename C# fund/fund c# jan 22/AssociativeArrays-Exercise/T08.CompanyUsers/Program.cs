using System;
using System.Collections.Generic;

namespace T08.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                AddCompanyMembers(companies, command);
                command = Console.ReadLine();
            }
            PrintResult(companies);
        }
        public static void PrintResult(Dictionary<string, List<string>> companies)
        {
            foreach (var currCompany in companies)
            {
                Console.WriteLine(currCompany.Key);
                foreach (var currId in currCompany.Value)
                {
                    Console.WriteLine($"-- {currId}");
                }
            }
        }
        public static void AddCompanyMembers(Dictionary<string, List<string>> companies, string command)
        {
            string[] givenCmd = command.Split(" -> ");
            string company = givenCmd[0];
            string ID = givenCmd[1];
            if (!companies.ContainsKey(company))
            {
                companies[company] = new List<string>();
            }
            if (!companies[company].Contains(ID))
            {
                companies[company].Add(ID);
            }
            command = Console.ReadLine();
        }
    }
}
