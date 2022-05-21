using System;

namespace lab1
{
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int answer = 0;

            if (n == 1)
            {
                for (int i = 0; i < customers.Length; ++i)
                {
                    answer += customers[i];
                }
            }
            else
            {
                int[] cash_registers = new int[n];

                for (int i = 0; i < cash_registers.Length; ++i)
                {
                    cash_registers[i] = 0;
                }

                for (int i = 0; i < customers.Length; ++i)
                {
                    int min = cash_registers[0];
                    int min_index = 0;

                    for (int j = 1; j < cash_registers.Length; ++j)
                    {
                        if (cash_registers[j] < min)
                        {
                            min = cash_registers[j];
                            min_index = j;
                        }

                        cash_registers[min_index] += customers[i];
                    }
                }

                int max = 0;

                for (int i = 0; i < cash_registers.Length; ++i)
                {
                    if (cash_registers[i] > max)
                    {
                        max = cash_registers[i];
                    }
                }

                answer = max;
            }
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };
            int count = 5;

            long output = HW1.QueueTime(array, count);
            Console.WriteLine(output);
        }
    }
}