using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Solution
    {

        static void Main()
        {
            int rows = 5;
            int columns = 5;
            int[,] Temp = new int[rows, columns];
            int counter = 1;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Temp[i, j] = counter;
                    counter++;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"[{ Temp[i, j]}]");
                }
                Console.WriteLine();
            }



        }
        public int[] Solution1(int rows, int columns, int[,] queries)
        {
            int[,] Temp = new int[rows,columns];
            int[] answer = new int[] { };
            int counter = 1;
            int[,] Rotate = new int[queries.GetLength(0), queries.GetLength(1)];

            for (int i = 0; i <rows; i++)
            {
                for (int j = 0; j <columns; j++)
                {
                    Temp[i, j] = counter;
                    counter++;
                }
            }

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                for( int j = 0; j < queries.GetLength(1); j++)
                {


                }

            }



            return answer;
        }
    }
}
