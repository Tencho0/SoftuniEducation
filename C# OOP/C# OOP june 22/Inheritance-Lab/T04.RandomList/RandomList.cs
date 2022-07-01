using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int elementIndex = random.Next(0,this.Count);
            string element = this[elementIndex];
            this.RemoveAt(elementIndex);
            return element;
        }
    }
}
