using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                int code = int.Parse(Console.ReadLine());
                int digitCounter = 1;
                int lastDigit = code;
                while (lastDigit % 10 == 0)
                {
                    digitCounter++;
                    lastDigit /= 10;
                }
                int mainDigit = code % 10;
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = (mainDigit - 2) * 3 + 1;
                }
                int letterIndex = offset + digitCounter - 1;
                char letter = (char)(letterIndex + 97);
                text += letter;
            }
            Console.WriteLine(text);

            //OR

            //int n = int.Parse(Console.ReadLine());
            //string text = string.Empty;
            //for (int i = 0; i < n; i++)
            //{
            //    int code = int.Parse(Console.ReadLine());
            //    string letter = string.Empty;
            //    switch (code)
            //    {
            //        case 2:
            //            letter = "a";
            //            break;
            //        case 22:
            //            letter = "b";
            //            break;
            //        case 222:
            //            letter = "c";
            //            break;
            //        case 3:
            //            letter = "d";
            //            break;
            //        case 33:
            //            letter = "e";
            //            break;
            //        case 333:
            //            letter = "f";
            //            break;
            //        case 4:
            //            letter = "g";
            //            break;
            //        case 44:
            //            letter = "h";
            //            break;
            //        case 444:
            //            letter = "i";
            //            break;
            //        case 5:
            //            letter = "j";
            //            break;
            //        case 55:
            //            letter = "k";
            //            break;
            //        case 555:
            //            letter = "l";
            //            break;
            //        case 6:
            //            letter = "m";
            //            break;
            //        case 66:
            //            letter = "n";
            //            break;
            //        case 666:
            //            letter = "o";
            //            break;
            //        case 7:
            //            letter = "p";
            //            break;
            //        case 77:
            //            letter = "q";
            //            break;
            //        case 777:
            //            letter = "r";
            //            break;
            //        case 7777:
            //            letter = "s";
            //            break;
            //        case 8:
            //            letter = "t";
            //            break;
            //        case 88:
            //            letter = "u";
            //            break;
            //        case 888:
            //            letter = "v";
            //            break;
            //        case 9:
            //            letter = "w";
            //            break;
            //        case 99:
            //            letter = "x";
            //            break;
            //        case 999:
            //            letter = "y";
            //            break;                    
            //        case 9999:
            //            letter = "z";
            //            break;
            //        case 0:
            //            letter = " ";
            //            break;
            //    }
            //    text += letter;
            //}
            //Console.WriteLine(text);
        }
    }
}
