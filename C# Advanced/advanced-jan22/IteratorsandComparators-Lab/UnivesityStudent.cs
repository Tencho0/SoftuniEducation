using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparatorsDemo
{
    class UnivesityStudent : Student, IHaveInstitutionName
    {
        public string UnivesityName { get; set; }

        public int Course { get; set; }

        public List<string> Courses { get; set; }

        public string GetName()
        {
            return UnivesityName;
        }

        public void PrintName(string name)
        {
        }
    }
}
