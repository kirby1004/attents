using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    struct Item
    {
        public string name;
        public int power;
        public Item(string name, int power)
        {
            this.name = name;
            this.power = power;
        }
    }


    class Time
    {
        long curTime = 0;

        static public float DeltaTime
        {
            get;
            private set;
        }
        public void Start()
        {
            curTime = DateTime.Now.Ticks;

        }
        public void UpDate()
        {
            long delta = DateTime.Now.Ticks - curTime;
            curTime = DateTime.Now.Ticks;
            DeltaTime = delta / 10000000f;
        }
    }

    class GameFrameWork
    {
        public GameFrameWork()
        {
            IsPlay = true;
        }
        public float TimeCount = 0.0f;
        public float Times = 1.0f;
        public bool IsPlay
        {
            get;
            private set;
        }
        public void InputProcess()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                        DelNum(1);
                        break;
                    case ConsoleKey.NumPad2:
                        DelNum(2);
                        break;
                    case ConsoleKey.NumPad3:
                        DelNum(3);
                        break;
                    case ConsoleKey.NumPad4:
                        DelNum(4);
                        break;
                    case ConsoleKey.NumPad5:
                        DelNum(5);
                        break;
                    case ConsoleKey.NumPad6:
                        DelNum(6);
                        break;
                }
            }
        }

        public void Update()
        {
            CountSecond();
            // DiceGame();
            if (InputScan == true)
            {
                AddNum();
                InputScan = false;
            }
        }
        bool reDraw = false;
        public void Draw()
        {
            if (reDraw == false) return;
            Console.Clear();
            foreach (int DiceList in DiceQ)
            {
                Console.Write($"[{DiceList}] ");
            }
            Console.WriteLine();
            reDraw = false;
        }

        Random rnd = new Random();
        public bool InputScan = false;
        List<int> DiceQ = new List<int>();
        void DelNum(int InputKey)
        {
            if (InputKey == DiceQ[DiceQ.Count])
            {
                DiceQ.RemoveAt(DiceQ.Count);
            }
        }
        public void DiceGame()
        {
          
            if( InputScan == true)
            {
                AddNum();
                InputScan = false;
                foreach(int DiceList in DiceQ)
                {
                   Console.Write($"[{DiceList}] ");
                }
            }
            if(DiceQ.Count() == 11)
            {
                IsPlay = false;
            }
        }
        public void AddNum()
        {
            if ( DiceQ.Count == 10)
            {
                GameOver();
                return;
            }
            DiceQ.Add(rnd.Next(1, 7));
            reDraw = true; 
        }
        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            IsPlay = false;
        }

        public void CountSecond()
        {
            TimeCount += Time.DeltaTime;
            if(TimeCount >=Times)
             {
                //Console.WriteLine($"{Times}초 지났습니다.");
                Times++;
                InputScan = true;
             }
           
        }


    }

    
    class Program
    {
        static void Main(string[] args)
        {
            GameFrameWork gfw = new GameFrameWork();
            bool isPlay = true;
            Time time = new Time();
            time.Start();

            while (isPlay)
            {
                time.UpDate();
                for(int i = 0; i < 10000; ++i)
                {
                    int n = i * i;
                }
                
                gfw.InputProcess();
                gfw.Update();
                gfw.Draw();

            }
        }
    }
}
