﻿namespace T09.ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        string GetName();
    }
}