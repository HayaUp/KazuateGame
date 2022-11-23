using System;

namespace KazuateGame
{
    public class Game
    {
        // 定数
        public readonly int RandomMinValue;
        public readonly int RandomMaxValue;
        public readonly int DisplayMaxValue;
        public readonly string ExitKey;
        public readonly string ReplayKey;

        private int UnknownValue;
        private Referee Referee;

        public Game()
        {
            RandomMinValue = 1;
            RandomMaxValue = 100 + 1;                  // + 1 をしないと99までしか得られない
            DisplayMaxValue = RandomMaxValue - 1;      // RandomMaxValue が + 1 で表示するので表示用を別に用意
            ExitKey = "q";
            ReplayKey = "1";

            Referee = new Referee();

            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            var random = new Random(DateTime.Now.Second);
            UnknownValue = random.Next(RandomMinValue, RandomMaxValue);

            ShowExplanationMessage();
        }

        /// <summary>
        /// ゲームの説明文を表示する
        /// </summary>
        private void ShowExplanationMessage()
        {
            Console.Clear();
            Console.WriteLine($"{RandomMinValue}～{DisplayMaxValue}の数値を入力し当ててください。");
            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");
        }

        /// <summary>
        /// メインループ
        /// </summary>
        public void Run()
        {
            while(true)
            {
                var input_value = Console.ReadLine();

                if(int.TryParse(input_value, out int input_number))
                {
                    var result = Referee.Judge(input_number, UnknownValue);
                    Referee.ShowMessage(result);

                    if(result == Referee.JudgmentResult.Equal)
                    {
                        Replay();
                    }
                }
                else if(input_value == ExitKey)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void Replay()
        {
            Console.WriteLine($"もう1度プレイされるなら {ReplayKey} を入力してください。");

            var input_value = Console.ReadLine();

            if(input_value == ReplayKey)
            {
                Initialize();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
