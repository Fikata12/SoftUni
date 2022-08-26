using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double bonus = 0;


            int chislo = int.Parse(Console.ReadLine());

            if (chislo <= 100)
            {
                bonus = 5;
            }
            else if (chislo > 100 && chislo <= 1000)
            {
                bonus = 0.2 * chislo;
            }
            else if (chislo > 1000)
            {
                bonus = 0.1 * chislo;
            }
            if (chislo % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (chislo % 10 == 5)
            {
                bonus = bonus + 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(chislo + bonus);
            double buget = double.Parse(Console.ReadLine());
            int brst = int.Parse(Console.ReadLine());
            double obleklo = double.Parse(Console.ReadLine());
            double dekor = 0.1 * buget;

            if (brst > 150)
            {
                obleklo = obleklo - 0.1 * obleklo;
            }

            double cena = dekor + obleklo * brst;

            if (cena > buget)
            {
                Console.WriteLine($"Not enough money!\nWingard needs {cena - buget:F2} leva more.");
            }
            else if (cena <= buget)
            {
                Console.WriteLine($"Action!\nWingard starts filming with {buget - cena:F2} leva left.");
            }
            string name = Console.ReadLine();
            int duration = int.Parse(Console.ReadLine());
            int breakdur = int.Parse(Console.ReadLine());
            double a = 1.00 / 8 * breakdur;
            double b = 1.00 / 4 * breakdur;
            double time = breakdur - a - b;

            if (time >= duration)
            {
                double lefttime = Math.Ceiling(time - duration);
                Console.WriteLine($"You have enough time to watch {name} and left with {lefttime} minutes free time.");
            }
            else
            {
                double neededtime = Math.Ceiling(duration - time);
                Console.WriteLine($"You don't have enough time to watch {name}, you need {neededtime} more minutes.");
            }
            double buget = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            double kc = 250 * n + m * 0.35 * 250 * n + p * 0.1 * 250 * n;

            if (n > m)
            {
                kc = kc - 0.15 * kc;
            }
            if (kc <= buget)
            {
                Console.WriteLine($"You have {buget - kc:F2} leva left!");
            }
            else if (kc > buget)
            {
                Console.WriteLine($"Not enough money! You need {kc - buget:F2} leva more!");
            }
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());
            int obshto = time1 + time2 + time3;
            int minuti = obshto / 60;
            int sekundi = obshto % 60;

            if (sekundi < 10)
            {
                Console.WriteLine(minuti + ":0" + sekundi);
            }
            else
            {
                Console.WriteLine(minuti + ":" + sekundi);
            }
            int chas = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            if (min == 45)
            {
                min = 0;
                chas++;
            }
            else if (min > 45)
            {
                min = min + 15 - 60;
                chas++;
            }
            else if (min < 45)
            {
                min = min + 15;
            }
            if (chas == 24)
            {
                chas = 0;
            }
            if (min < 10)
            {
                Console.WriteLine(chas + ":0" + min);

            }
            else if (min >= 10)
            {
                Console.WriteLine(chas + ":" + min);

            }
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
            if (prihodi >= ce)
            {
                Console.WriteLine($"Yes! {prihodi - ce:F2} lv left.");
            }
            else if (prihodi < ce)
            {
                Console.WriteLine($"Not enough money! {ce - prihodi:F2} lv needed.");
            }
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time1m = double.Parse(Console.ReadLine());
            double sd = Math.Floor(distance / 15) * 12.5;
            double time = time1m * distance + sd;
            if (time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:F2} seconds.");
            }
            else if (time >= record)
            {
                Console.WriteLine($"No, he failed! He was {time - record:F2} seconds slower.");
            }
            double result = 0;
            string vid = Console.ReadLine();

            if (vid == "square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a;
            }
            else if (vid == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }
            else if (vid == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a * Math.PI;
            }
            else if (vid == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b / 2;
            }

            Console.WriteLine($"{result:F3}");
            int p = int.Parse(Console.ReadLine());
            if (p % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
            double ocenka = double.Parse(Console.ReadLine());
            if (ocenka >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
            double p = double.Parse(Console.ReadLine());
            double v = double.Parse(Console.ReadLine());
            if (p >= v)
            {
                Console.WriteLine(p);
            }
            else if (v >= p)
            {
                Console.WriteLine(v);
            }
            int ch = int.Parse(Console.ReadLine());
            if (ch < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (ch >= 100 && ch <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (ch > 200)
            {
                Console.WriteLine("Greater than 200");
            }
            string pas = Console.ReadLine();

            if (pas == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
            double sp = double.Parse(Console.ReadLine());

            if (sp <= 10)
            {
                Console.WriteLine("slow");
            }
            else if (sp > 10 && sp <= 50)
            {
                Console.WriteLine("average");
            }
            else if (sp > 50 && sp <= 150)
            {
                Console.WriteLine("fast");
            }
            else if (sp > 150 && sp <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
