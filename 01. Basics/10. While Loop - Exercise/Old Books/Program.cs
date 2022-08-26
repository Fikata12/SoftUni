using System;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int bookCounter = 0;
            bool isBookFound = false;
            string currentBook = Console.ReadLine();

            while (currentBook != "No More Books")
            {
                if (currentBook == book)
                {
                    isBookFound = true;
                    break;  
                }
                bookCounter++;
                currentBook = Console.ReadLine();
            }
            
            if (isBookFound)
            {
                Console.WriteLine($"You checked {bookCounter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter} books.");
            }
        }
    }
}
