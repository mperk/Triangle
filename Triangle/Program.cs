using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string path = Directory.GetCurrentDirectory() + "/triangle.txt";
            var items = new List<Coordinate>();
            int x = 0;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                var numbers = line.Split(" ");
                for (int j = 0; j < numbers.Length; j++)
                {
                    items.Add(new Coordinate(x, j, Convert.ToInt32(numbers[j].ToString()) ));
                }
                x++;
            }
            file.Close();

            Console.Write(maxPathSum(items));
            Console.ReadLine();
        }

        static long maxPathSum(List<Coordinate> triangle)
        {
            long sum = triangle[0].Value;
            if (triangle.Count < 2) return sum;

            var previous = triangle[0];
            for (int i = 1; i <= triangle.LastOrDefault().X ; i++)
            {
                var neighbours = triangle.Where(t => t.X == i)
                                         .Where(t => t.Y == previous.Y || t.Y == previous.Y + 1 || t.Y == previous.Y - 1)
                                         .ToList();
                var temp = new Coordinate(0,0,0);
                foreach (var item in neighbours) // max 3 neighbours
                {
                    if(item.Value > temp.Value && !IsPrime(item.Value))
                    {
                        temp = item;
                    }
                }
                previous = temp;
                sum += previous.Value;
            }
            return sum;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
