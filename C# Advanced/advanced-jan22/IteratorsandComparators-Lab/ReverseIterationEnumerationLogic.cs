using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparatorsDemo
{
    class ReverseIterationEnumerationLogic : IEnumerator<double>
    {
        private List<double> items;
        private int index;

        public ReverseIterationEnumerationLogic(List<double> items)
        {
            this.items = items;
            index = items.Count;
        }

        public double Current => items[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index--;
            if (index < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            index = items.Count;
        }

        public void Dispose()
        {
        }
    }
}
