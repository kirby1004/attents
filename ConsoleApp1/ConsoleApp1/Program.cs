using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        enum Signal
        {
            Sum,
            Minus,
            Mul,
            div,
            blank
        }

        static void Main(string[] args)
        {

            Random rand = new Random();
            Signal Sign, player,SecondAnswer=Signal.blank;
            int FirstNum, SecondNum=0, TotalNum=0;
            bool OtherCal;
            int OtherTest,Count;
            FirstNum = rand.Next(0, 10);
            Sign = (Signal)rand.Next(0, 4);
            bool Check;
            int Answer;

            switch (Sign)
            {
                case Signal.Sum:
                case Signal.Minus:
                case Signal.Mul:
                    SecondNum = rand.Next(0, 10);
                    break;
                case Signal.div:
                    SecondNum = rand.Next(1, 10);
                    break;
                default:
                    break;
            }

            switch (Sign)
            {
                case Signal.Sum:
                    TotalNum = FirstNum + SecondNum;
                    break;
                case Signal.Minus:
                    TotalNum = FirstNum - SecondNum;
                    break;
                case Signal.Mul:
                    TotalNum = FirstNum * SecondNum;
                    break;
                case Signal.div:
                    TotalNum = FirstNum / SecondNum;
                    break;
                default:
                    break;
            }// 값을미리 저장해두기

            switch (Sign)
            {
                case Signal.Sum:
                    if (TotalNum == FirstNum * SecondNum)
                    {
                        SecondAnswer = Signal.Mul;
                    }
                    break;
                case Signal.Minus:
                    if (TotalNum == FirstNum / SecondNum)
                    {
                        SecondAnswer = Signal.div;
                    }
                    break;
                case Signal.Mul:
                    if (TotalNum == FirstNum + SecondNum)
                    {
                        SecondAnswer = Signal.Mul;
                    }
                    break;
                case Signal.div:
                    if (TotalNum == FirstNum - SecondNum)
                    {
                        SecondAnswer = Signal.Minus;
                    }
                    break;
                default:
                    break;
            }

            Check = int.TryParse(Console.ReadLine(), out Answer);
            player = (Signal)Answer;

            switch (Sign)
             {
                 case Signal.Sum:
                     if ((player == Signal.Sum)||(player==SecondAnswer))
                     {
                         Console.WriteLine("정답입니다");
                     }
                     else
                     {
                         Console.WriteLine("틀렸습니다");
                     }
                     break;
                 case Signal.Minus:
                    if ((player == Signal.Minus) || (player == SecondAnswer))
                    {
                         Console.WriteLine("정답입니다");
                     }
                     else
                     {
                         Console.WriteLine("틀렸습니다");
                     }
                     break;
                 case Signal.Mul:
                    if ((player == Signal.Mul) || (player == SecondAnswer))
                    {
                         Console.WriteLine("정답입니다");
                     }
                     else
                     {
                         Console.WriteLine("틀렸습니다");
                     }
                     break;
                case Signal.div:
                     if ((player == Signal.div) || (player == SecondAnswer))
                    {
                         Console.WriteLine("정답입니다");
                     }
                     else
                     {
                         Console.WriteLine("틀렸습니다");
                     }
                     break;
                 default:
                     Console.WriteLine("사칙 연산 기호를 입력해주세요.");
                     break;
             }
           


        }

    




    }
}

