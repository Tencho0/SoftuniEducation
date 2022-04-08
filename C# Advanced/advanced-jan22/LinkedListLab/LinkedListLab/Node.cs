﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLab
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
