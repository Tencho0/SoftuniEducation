using System;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine(); 
            int i = 0;
            string currentlyBook = Console.ReadLine();

            while (currentlyBook != "No More Books")
            {
                if (bookName == currentlyBook)
                {
                    Console.WriteLine($"You checked {i} books and found it.");
                    return;
                }

                i++;
                currentlyBook = Console.ReadLine();
            }
            if (currentlyBook == "No More Books")
            {

                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {i} books.");
                
            }
        }
    }
}
