﻿using System;
using System.Collections.Generic;
using System.Text;

namespace T07.RawData
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
