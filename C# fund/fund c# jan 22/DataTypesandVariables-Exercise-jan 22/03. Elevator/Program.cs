using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int modul = numberOfPeople % capacity;
            int courses = 0;
            if (modul != 0)
                courses = (numberOfPeople / capacity) + 1;
            else
                courses = numberOfPeople / capacity;
            Console.WriteLine(courses);
        }
    }
}
