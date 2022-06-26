using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private Dictionary<string, Renovator> renovators;
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new Dictionary<string, Renovator>();
        }
        public int Count => Renovators.Count;
        public Dictionary<string, Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                return $"Invalid renovator's information.";
            if (Renovators.Count >= this.NeededRenovators)
                return $"Renovators are no more needed.";
            if (renovator.Rate > 350)
                return $"Invalid renovator's rate.";

            Renovators.Add(renovator.Name, renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            if (Renovators.ContainsKey(name))
            {
                Renovators.Remove(name);
                return true;
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            // Renovators.Values.Count(x => x.Type == type);
            List<Renovator> removeRenovators = Renovators.Values.Where(x => x.Type == type).ToList();
            foreach (var item in removeRenovators)
                Renovators.Remove(item.Name);
            return removeRenovators.Count;
        }
        public Renovator HireRenovator(string name)
        {
            if (Renovators.ContainsKey(name))
            {
                Renovators[name].Hired = true;
                return Renovators[name];
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Values.Where(x => x.Days >= days).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {project}:");
            foreach (var item in renovators.Values.Where(x => x.Hired == false))
                sb.AppendLine(item.ToString());
  
            return sb.ToString().TrimEnd();
        }
    }
}
