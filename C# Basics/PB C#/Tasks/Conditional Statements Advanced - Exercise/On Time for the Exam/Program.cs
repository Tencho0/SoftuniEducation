using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMitunes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int difference = 0;
            int hour = 0;
            int minutes = 0;

            examMitunes += examHour * 60;
            arrivalMinutes += arrivalHour * 60;
            if ( arrivalMinutes > examMitunes)
            {
                Console.WriteLine("Late");
                difference = arrivalMinutes - examMitunes;
                if (difference < 60) 
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour} : {minutes:d2} hours after the start");
                }
            }
            else if (arrivalMinutes < examMitunes - 30)
            {
                Console.WriteLine("Early");
                difference = examMitunes - arrivalMinutes;
                if (difference<60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour} : {minutes:d2} hours before the start");
                }
            }
            else if (examMitunes == arrivalMinutes)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("On time");
                difference = examMitunes - arrivalMinutes;
                Console.WriteLine($"{difference} minutes before the start");
            }
        }
    }
}
