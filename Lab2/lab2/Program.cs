using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); 
            const int size = 10;
            
            RomanNumber[] numbers = new RomanNumber[size];

            for (int i = 0; i < size; i++)
            {
                int tmp = rand.Next();
                ushort x = (ushort)tmp;
                numbers[i] = new RomanNumber(x);
                Console.WriteLine(numbers[i].ToString() + " " + x);
            }

            Array.Sort<RomanNumber>(numbers);
            Console.WriteLine();

            foreach (RomanNumber i in numbers)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine(RomanNumber.Add(new RomanNumber(5), new RomanNumber(1)));
            Console.WriteLine(RomanNumber.Sub(new RomanNumber(8), new RomanNumber(3)));
            Console.WriteLine(RomanNumber.Mul(new RomanNumber(6), new RomanNumber(9)));
            Console.WriteLine(RomanNumber.Div(new RomanNumber(22), new RomanNumber(11)));
        }
    }
}