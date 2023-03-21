using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0313
{
    /*
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
    */

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
        enum SlotItem
        {
            None,AllClear,TimeStop,SlowTime,Fever,AllChange,DoubleAttack,ChainAttack,HighRiskHighReturn,SuperFever
        }

        public float TimeCount = 0.0f; //런타임
        public float Times = 1;
        bool reDraw = false;
        Random rnd = new Random();
        public bool InputScan = false;
        List<int> DiceQ = new List<int>();
        int Score = 0 ;
        int Exp = 0;
        int Level = 0;
        int ScoreMul = 1;
        double LevelCycle = 1; // 생성주기
        double InputTIme = 0; // 다음생성시각
        double ItemCounter = 0; //아이템 런타임
        bool TimeStopSwitch = false;
        double ItemTimer = 0; // 현재 사용 아이템 지속시간
        int ItemCheck = 0; 
        // double FirstLevelCycle = 2;
        bool ItemEffectLeft = false; // 아이템 사용종료여부
        int ItemLeftCount = 0; //횟수형 아이템 잔여횟수
        bool SuperFeverOn = false; // 슈퍼피버 사용
        bool ComboSucces = false; // 연속정답여부 저장
        int Combo = 1; // 연속 정답 횟수


        SlotItem[] itemSlots = new SlotItem[2];
        SlotItem UsedItem = SlotItem.None;
        SlotItem UsingItem = SlotItem.None;
        public GameFrameWork()
        {
            IsPlay = true;
        }
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
                int inputNum = (int)keyInfo.Key - (int)ConsoleKey.NumPad0;
                switch (UsedItem)
                {
                    case SlotItem.AllClear:
                        Score += DiceQ.Count * 10;
                        Exp += DiceQ.Count * 10;
                        DiceQ.Clear();
                        UsedItem = SlotItem.None;
                        reDraw = true;
                        break;
                    case SlotItem.TimeStop:
                        TimeStopSwitch = true;
                        TimeStop();
                        UsedItem = SlotItem.None;
                        reDraw = true;
                        break;
                    case SlotItem.SlowTime:
                        ItemTimer = 5.0;
                        ItemEffectLeft = true;
                        LevelCycle *= 2;
                        UsedItem = SlotItem.None;
                        UsingItem = SlotItem.SlowTime;
                        reDraw = true;
                        break;
                    case SlotItem.Fever:
                        ItemTimer = 5;
                        ScoreMul = 2;
                        ItemEffectLeft = true;
                        UsedItem = SlotItem.None;
                        UsingItem = SlotItem.Fever;
                        reDraw = true;
                        break;
                    case SlotItem.AllChange:
                        int temp = DiceQ.Count();
                        DiceQ.Clear();
                        int TempValue = rnd.Next(1, 7);
                        for (int i = 0; i < temp-1; i++)
                        {
                            DiceQ.Add( TempValue);
                        }
                        UsedItem = SlotItem.None;
                        break;
                    case SlotItem.DoubleAttack:
                        ItemLeftCount = 5;
                        UsingItem = SlotItem.DoubleAttack;
                        UsedItem = SlotItem.None;
                        break;
                    case SlotItem.ChainAttack:
                        DiceQ.RemoveAll(n => n == inputNum);
                        UsedItem = SlotItem.None;
                        break;
                    case SlotItem.HighRiskHighReturn:
                        LevelCycle /= 2;
                        ScoreMul *= 10;
                        ItemEffectLeft = true;
                        UsedItem = SlotItem.None;
                        UsingItem = SlotItem.HighRiskHighReturn;
                        break;
                    case SlotItem.SuperFever:
                        SuperFeverOn = true;
                        ComboSucces = true;
                        UsedItem = SlotItem.None;
                        UsingItem = SlotItem.SuperFever;
                        break;
                    default:
                        if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            UseItem(itemSlots[0]);
                            itemSlots[0] = SlotItem.None;
                        }
                        else if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            UseItem(itemSlots[1]);
                            itemSlots[1] = SlotItem.None;
                        }
                        else
                        {              
                            DelNum(inputNum);
                        }
                        break;
                }

            }
        }


        public void Update()
        {
            CountSecond();
            LevelCheck();
            if (ItemEffectLeft == true)
            {
                ItemTImeCounter(ItemTimer);
                switch (UsingItem)
                {
                    case SlotItem.SlowTime:
                        if(ItemEffectLeft == false)
                        {
                            LevelCycle /= 2;
                            reDraw = true;
                            UsingItem = SlotItem.None;
                            break;
                        }
                        break;
                    case SlotItem.Fever:
                        if (ItemEffectLeft == false)
                        {
                            ScoreMul = 1;
                            reDraw = true;
                            UsingItem = SlotItem.None;
                            break;
                        }
                        break;
                    case SlotItem.HighRiskHighReturn:
                        if (ItemEffectLeft == false)
                        {
                            LevelCycle *= 2;
                            ScoreMul = 1;
                            reDraw = true;
                            UsingItem = SlotItem.None;
                            break;
                        }
                        break;
                }
            }
            if ( TimeStopSwitch == true)
            {
                TimeStop();
                return;
            }
            if (InputScan == true)
            {
                AddNum();
                InputScan = false;
            }
        }
        public void Draw()
        {
            if (reDraw == false) return;
            Console.Clear();
            Console.WriteLine($"레벨 : {Level} / 현재 점수 : {Score} 점 최대갯수 {10+Level}");
            switch (UsedItem)
            {
                case SlotItem.None:
                    break;
                case SlotItem.AllClear:
                    Console.WriteLine("<올클리어> : 모든 숫자 삭제!");
                    break;
                case SlotItem.TimeStop:
                    Console.WriteLine("<타임스톱> : 5초간 시간정지!");
                    break;
                case SlotItem.SlowTime:
                    Console.WriteLine("<슬로타임> : 10초간 천천히!");
                    break;
                case SlotItem.Fever:
                    Console.WriteLine("<피버타임> : 5초간 점수 2배!");
                    break;
                case SlotItem.AllChange:
                    Console.WriteLine("<올체인지> : 모든 숫자 변경!");
                    break;
                case SlotItem.DoubleAttack:
                    Console.WriteLine("<더블어택> : 한번에 두개씩 삭제!");
                    break;
                case SlotItem.ChainAttack:
                    Console.WriteLine("<체인어택> : 지우고 싶은 숫자를 선택하세요!");
                    break;
                case SlotItem.HighRiskHighReturn:
                    Console.WriteLine("<하이리스크> : 5초간 속도2배 점수 10배!");
                    break;
                case SlotItem.SuperFever:
                    Console.WriteLine("<슈퍼피버> : 콤보수만큼 점수 배율 증가!");
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            switch (UsingItem)
            {
                case SlotItem.None:
                    break;
                case SlotItem.AllClear:
                    Console.WriteLine("<올클리어> : 모든 숫자 삭제!");
                    break;
                case SlotItem.TimeStop:
                    Console.WriteLine("<타임스톱> : 5초간 시간정지!");
                    break;
                case SlotItem.SlowTime:
                    Console.WriteLine("<슬로타임> : 10초간 천천히!");
                    break;
                case SlotItem.Fever:
                    Console.WriteLine("<피버타임> : 5초간 점수 2배!");
                    break;
                case SlotItem.AllChange:
                    Console.WriteLine("<올체인지> : 모든 숫자 변경!");
                    break;
                case SlotItem.DoubleAttack:
                    Console.WriteLine("<더블어택> : 한번에 두개씩 삭제!");
                    break;
                case SlotItem.ChainAttack:
                    Console.WriteLine("<체인어택> : 지우고 싶은 숫자를 선택하세요!");
                    break;
                case SlotItem.HighRiskHighReturn:
                    Console.WriteLine("<하이리스크> : 5초간 속도2배 점수 10배!");
                    break;
                case SlotItem.SuperFever:
                    Console.WriteLine("<슈퍼피버> : 콤보수만큼 점수 배율 증가!");
                    Console.WriteLine($"{Combo} 콤보!");
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            for (int i = DiceQ.Count-1;  i > -1; i--)
            {

                Console.Write($"[{DiceQ[i]}] ");
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach(SlotItem item in itemSlots)
            {
                switch (item)
                {
                    case SlotItem.None:
                        Console.Write("[비어있음]");
                        break;
                    case SlotItem.AllClear:
                        Console.Write("[올클리어]");
                        break;
                    case SlotItem.TimeStop:
                        Console.Write("[타임스탑]");
                        break;
                    case SlotItem.SlowTime:
                        Console.Write("[슬로타임]");
                        break;
                    case SlotItem.Fever:
                        Console.Write("[피버타임]");
                        break;
                    case SlotItem.AllChange:
                        Console.Write("[바꿔버리기]");
                        break;
                    case SlotItem.DoubleAttack:
                        Console.Write("[더블어택]");
                        break;
                    case SlotItem.ChainAttack:
                        Console.Write("[체인어택]");
                        break;
                    case SlotItem.HighRiskHighReturn:
                        Console.Write("[하이리스크]");
                        break;
                    case SlotItem.SuperFever:
                        Console.Write("[슈퍼피버]");
                        break;
                }
            }

            Console.WriteLine();
            reDraw = false;
        }


        //All Clear - 전체삭제
        //Time Stop - 5초간 시간정지
        //slow Time - 10초간 레벨1의속도로
        //Fever -5초간 점수 2배
        //All Change - 모든 숫자를 랜덤한 숫자로 변경
        //Double Attack -10회간 2개씩 삭제
        //Chain Attack - 아이템 사용후 첫 입력에 해당하는 숫자 전체 제거
        //High Risk High Return - 5초간 현재속도의 2배로 출력되며 100점씩 획득가능한상태가됨
        // SuperFever - 

        void UseItem(SlotItem item)
        {
            reDraw = true;
            switch (item)
            {
                case SlotItem.AllClear:
                    UsedItem = SlotItem.AllClear;
                    break;
                case SlotItem.TimeStop:
                    UsedItem = SlotItem.TimeStop;
                    break;
                case SlotItem.SlowTime:
                    UsedItem = SlotItem.SlowTime;
                    break;
                case SlotItem.Fever:
                    UsedItem = SlotItem.Fever;
                    break;
                case SlotItem.AllChange:
                    UsedItem = SlotItem.AllChange;
                    break;
                case SlotItem.DoubleAttack:
                    UsedItem = SlotItem.DoubleAttack;
                    break;
                case SlotItem.ChainAttack:
                    UsedItem = SlotItem.ChainAttack;
                    break;
                case SlotItem.HighRiskHighReturn:
                    UsedItem = SlotItem.HighRiskHighReturn;
                    break;
                case SlotItem.SuperFever:
                    UsedItem = SlotItem.SuperFever;
                    break;
                default:
                    break;
            }
        }
        void TimeStop()
        {
            ItemCounter += Time.DeltaTime;
            if (ItemCounter >= 10.0)
            {
                TimeStopSwitch = false;
                ItemCounter = 0.0;
            }
        }
        void ItemTImeCounter(double n)
        {
            ItemCounter += Time.DeltaTime;
            if ( ItemCounter >= n)
            {

                ItemEffectLeft = false;
                ItemCounter = 0.0;
            }
        }
        void ItemLeftCounter(int n)
        {
            if(ItemLeftCount == 0)
            {

            }
        }
 
        void DelNum(int InputKey)
        {
            if (DiceQ.Count == 0 || TimeStopSwitch == true) {
                reDraw = true;
                return;
            }
            if (DiceQ[0] == InputKey)
            {
                if (UsingItem == SlotItem.DoubleAttack)
                {
                    DiceQ.RemoveAt(0);
                    DiceQ.RemoveAt(0);
                    Score += 20 * ScoreMul;
                    Exp += 20;
                    ItemLeftCount--;
                    reDraw = true;
                    ItemCheck += 2;
                    if (ItemCheck >= 4)
                    {
                        ItemCheck -= 4;
                        //아이템추가
                        AddItem();
                    }
                    if (ItemLeftCount == 0)
                    {
                        UsingItem = SlotItem.None;
                    }
                }
                else if ( UsingItem == SlotItem.SuperFever)
                {
                    if (ComboSucces == true)
                    {
                        DiceQ.RemoveAt(0);
                        ++Combo;
                        ScoreMul = Combo;
                        Score += 10 * ScoreMul;
                        Exp += 10;
                        reDraw = true;
                    }
                    if (++ItemCheck >= 4)
                    {
                        ItemCheck -= 4;
                        //아이템추가s
                        AddItem();
                    }
                }
                else
                {
                    DiceQ.RemoveAt(0);
                    Score += 10 * ScoreMul;
                    Exp += 10;

                    reDraw = true;
                    if (++ItemCheck >= 4)
                    {
                        ItemCheck = 0;
                        //아이템추가
                        AddItem();
                    }
                }
            }
            else if ( DiceQ[0] != InputKey)
            {

                if ( SuperFeverOn == true)
                {
                    SuperFeverOn = false;
                    ComboSucces = false;
                    UsingItem = SlotItem.None;
                    Combo = 1;
                }
                Score = (Score-10) <= 0 ? 0 : Score-10;
                reDraw = true;
            }
        }

        void AddItem()
        {
            for(int i = 0; i < itemSlots.Length; ++i)
            {
                if(itemSlots[i] == SlotItem.None)
                {

                    double temp = rnd.Next(0, 100);
                    if ( temp < 2)
                    {
                        itemSlots[i] = SlotItem.SuperFever;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 2||temp < 12)
                    {
                        itemSlots[i] = SlotItem.Fever;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 12 || temp < 25)
                    {
                        itemSlots[i] = SlotItem.DoubleAttack;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 25 || temp < 37)
                    {
                        itemSlots[i] = SlotItem.AllChange;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 37 || temp < 50)
                    {
                        itemSlots[i] = SlotItem.AllClear;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 50 || temp < 62)
                    {
                        itemSlots[i] = SlotItem.HighRiskHighReturn;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 62 || temp < 75)
                    {
                        itemSlots[i] = SlotItem.ChainAttack;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 75 || temp < 87)
                    {
                        itemSlots[i] = SlotItem.TimeStop;
                        reDraw = true;
                        break;
                    }
                    else if (temp >= 87 || temp < 100)
                    {
                        itemSlots[i] = SlotItem.SlowTime;
                        reDraw = true;
                        break;
                    }

                }
            }
        }

        public void AddNum()
        {
            {
                if (DiceQ.Count == 10 + Level)
                {
                    GameOver();
                    return;
                }
                DiceQ.Add(rnd.Next(1, 7));
                reDraw = true;
            }
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            IsPlay = false;
        }

        void GameWin()
        {
            Console.Clear();
            Console.WriteLine("Game Win");
            IsPlay = false;
        }
        public void LevelCheck()
        {
            if (Exp >= 150)
            {
                Exp -= 150;
                Level++;
                LevelCycle *= 0.9;
            }
            if (Level == 20)
            {
                GameWin();
                return;
            }
            if (TimeCount >= InputTIme)
            {                
                InputTIme += LevelCycle;
                InputScan = true;
            }
        }
        public void CountSecond()
        {
            TimeCount += Time.DeltaTime;
            if (TimeCount >= Times)
            {
                Times++;
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
                for (int i = 0; i < 10000; ++i)
                {
                    int n = i * i;
                }

                gfw.InputProcess();
                gfw.Update();
                gfw.Draw();

                //All Clear - 전체삭제
                //Time Stop - 5초간 시간정지
                //slow Time - 10초간 레벨1의속도로
                //Fever -5초간 점수 2배
                //All Change - 모든 숫자를 랜덤한 숫자로 변경
                //Double Attack -10회간 2개씩 삭제
                //Chain Attack - 아이템 사용후 첫 입력에 해당하는 숫자 전체 제거
                //High Risk High Return - 5초간 현재속도의 2배로 출력되며 100점씩 획득가능한상태가됨
                //아이템은 두개까지만 저장가능
                //아이템 사용키
                //<- : 1번슬롯사용 -> : 2번슬롯사용
                //8개의 숫자를 지울때마다 


            }
        }
    }
}
