using System;

namespace ConsoleApp2
{
    public static class TEST
    {
        static void Main()
        {
            int GalaxySeed = 14171500;
            Random random = new Random(GalaxySeed);
            random.Next();
            random.NextDouble();
            random.NextDouble();
            random.NextDouble();
            random.NextDouble();
            int StarSeed = random.Next();
            Console.WriteLine(StarSeed);
            Console.WriteLine("Should Be 1826783713");
            Console.ReadLine();
        }

    }
}