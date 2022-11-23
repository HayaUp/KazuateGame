using System;

namespace KazuateGame
{
    public class Game
    {
        // 定数
        public readonly string ExitKey;
        public readonly string ReplayKey;

        private Problem Problem;
        private Referee Referee;

        public Game()
        {
            ExitKey = "q";
            ReplayKey = "1";

            Problem = new Problem();
            Referee = new Referee();

            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            Problem.Initialize();

            ShowExplanationMessage();
        }

        /// <summary>
        /// ゲームの説明文を表示する
        /// </summary>
        private void ShowExplanationMessage()
        {
            Console.Clear();
            Console.WriteLine($"{Problem.ValueRange}の数値を入力し当ててください。");
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
                    var result = Referee.Judge(input_number, Problem.UnknownValue);
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
