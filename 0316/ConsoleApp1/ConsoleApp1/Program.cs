using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 12;
            bool answer = true;
            int test = 0;
            int temp = x;
            for (int i = 0; i < 5; i++)
            {
                if (temp / 10 == 0)
                {
                    test += temp;
                    break;
                }
                else
                {
                    test += (temp % 10);
                    temp /= 10;
                }
            }
            if (x % test == 0)
                answer = true;
            else
                answer = false;

            Console.WriteLine(answer);

        }


    }
}
