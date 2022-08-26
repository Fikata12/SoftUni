using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort lostGamesCount = ushort.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());

            ushort trashedHeadset = (ushort)(lostGamesCount / 2);
            ushort trashedMouse = (ushort)(lostGamesCount / 3);
            ushort trashedKeyboard = (ushort)(trashedMouse / 2);
            ushort trashedDisplay = (ushort)(trashedKeyboard / 2);
           
            float expenses = trashedHeadset * headsetPrice + trashedMouse * mousePrice + trashedKeyboard * keyboardPrice + trashedDisplay * displayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
