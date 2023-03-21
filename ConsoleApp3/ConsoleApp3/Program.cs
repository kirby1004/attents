using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            PrimeTest(a);


        }

        /*
        public int[] GetConcatenation(int[] nums)
        {
            int[] ans = new int[(nums.Length) * 2];

        }
        static int[] BuildArray(int[] nums)
        {
            int[] ans = new int[nums.Length];

        }


        static int TotalSum(int x,int y)
        {
            if (x == y) return x;
            return x + TotalSum(x+1, y);
        }



        static int Fibo(int n)
        {
            if (n == 1) return 1;
            if (n ==2 ) return 2;

            return Fibo(n - 2) + Fibo(n - 1);
        }



        static int NewPow(int x , int y)
        {
            if (y == 1) return x;
            return x * NewPow(x, y-1);
        }


        static int Pow(int x,int y)
        {
            int Mul=1;
            for (int i =0; i <y; i++)
            {
                Mul = Mul * x;
            }
            if (y == 0)
                Mul = 1;
            return Mul;
        }
       */

        static void PrimeTest(int k)
        {
            bool Count = false;
            int sum = 0;
            int SecondCount = 0;

            for (int i = 2; i < k; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        Count = true;
                        break;
                    }
                }

                if (Count == false)
                {
                    sum += i;
                    Console.WriteLine(i);
                    SecondCount++;
                }
                else if (Count == true)
                    Count = false;
            }
            Console.WriteLine($"{sum} , {SecondCount}");
        }



    }
}
