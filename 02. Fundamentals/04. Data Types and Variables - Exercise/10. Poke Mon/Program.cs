using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong N = ulong.Parse(Console.ReadLine());
            uint M = uint.Parse(Console.ReadLine());
            ushort Y = ushort.Parse(Console.ReadLine());
            ulong originalN = N;
            ushort pokeCounter = 0;

            while (N >= M)
            {
                pokeCounter++;
                N -= M;
                if (N == originalN / 2)
                {
                    if (Y > 0)
                    {
                        N /= Y;
                    }
                }
            }
            Console.WriteLine(N);
            Console.WriteLine(pokeCounter);
        }
    }
}
