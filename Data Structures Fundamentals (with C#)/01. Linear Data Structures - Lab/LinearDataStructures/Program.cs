namespace LinearDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Problem01.List.List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Remove(3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(list.Count);
        }
    }
}