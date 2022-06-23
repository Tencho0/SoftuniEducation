using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private Dictionary<string,Employee> data;
        private string name;
        private int capacity;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new Dictionary<string, Employee>();
        }
        public int Count => Data.Count;
        public Dictionary<string,Employee> Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public void Add(Employee employee)
        {
            if (Data.Count < Capacity && !Data.ContainsKey(employee.Name))
            {
                Data.Add(employee.Name, employee);
            }
        }
        public bool Remove(string name)
        {
            if (Data.ContainsKey(name))
            {
                Data.Remove(name);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            int max = Data.Values.Max(x => x.Age);
            return Data.Values.First(x => x.Age >= max);
        }
        public Employee GetEmployee(string name)
        {
            return Data[name];
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var (name, currEmployee) in Data)
                sb.AppendLine(currEmployee.ToString());

            return sb.ToString().TrimEnd();            
        }
    }
}
