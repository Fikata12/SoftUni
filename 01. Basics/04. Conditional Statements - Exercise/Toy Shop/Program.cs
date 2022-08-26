using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double ce = double.Parse(Console.ReadLine());
            int bp = int.Parse(Console.ReadLine());
            int bgk = int.Parse(Console.ReadLine());
            int bpm = int.Parse(Console.ReadLine());
            int bm = int.Parse(Console.ReadLine());
            int bk = int.Parse(Console.ReadLine());
            double prihodi = bp * 2.60 + bgk * 3 + bpm * 4.10 + bm * 8.20 + bk * 2;
            if (bp + bgk + bpm + bm + bk >= 50)
            {
                prihodi = prihodi - 0.25 * prihodi;
            }
            prihodi = prihodi - 0.1 * prihodi;
            if (prihodi>=ce)
            {
                Console.WriteLine($"Yes! {prihodi - ce:F2} lv left.");
            }
            else if (prihodi<ce)
            {
                Console.WriteLine($"Not enough money! {ce - prihodi:F2} lv needed.");
            }
            
        }
    }
}
