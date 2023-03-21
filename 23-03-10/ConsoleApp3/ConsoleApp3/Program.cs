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


            
            Random rnd = new Random();

            List<int> list = new List<int>();
            int[] Temp =new int[45];
            
            for(int i = 0; i <45; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < 45; i++)
            {
                int n = rnd.Next(0, list.Count);
                Temp[i] = list[n];
                list.RemoveAt(n);
            }
            for (int i = 0; i < 45; i++)
            {
                list.Add(Temp[i]);
            }
            foreach (int n in list)
            {
                Console.Write($" [{n}] ");
                
            }
            Console.WriteLine();

            int x=-133333, y=2;
            long z;
            z =(long) x * y;
            
        }
    }
}
