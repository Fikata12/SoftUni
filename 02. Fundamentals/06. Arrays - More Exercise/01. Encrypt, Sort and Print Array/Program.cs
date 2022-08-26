using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                int code = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    switch (name[j])
                    {
                        case 'a':
                        case 'o':
                        case 'u':
                        case 'i':
                        case 'e':
                        case 'A':
                        case 'O':
                        case 'U':
                        case 'I':
                        case 'E':
                            code += (int)name[j] * name.Length;
                            break;
                        default:
                            code += (int)name[j] / name.Length;
                            break;
                    }
                }
                arr[i] = code;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int a = arr[i];
                        arr[i] = arr[j];
                        arr[j] = a;
                    }
                }

            }
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            Console.
        }
    }
}
