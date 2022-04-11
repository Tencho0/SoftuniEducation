using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparatorsDemo
{

    class HighSchoolStudent : Student, IHaveInstitutionName
    {
        public HighSchoolStudent()
            : this("NPMG")
        {

        }

        public HighSchoolStudent(string name)
        {

        }

        public string HighSchool { get; set; }

        public int Grade { get; set; }

        public string GetName()
        {
            return HighSchool;
        }

        public void PrintName(string name)
        {
        }
    }
}
