using System;

namespace KazuateGame
{
    public class Game
    {
        // 定数
        public readonly string ExitKey;
        public readonly string ReplayKey;

        private Problem Problem;
        private Player Player;
        private Referee Referee;

        public Game()
        {
            Console.Title = "数当てゲーム";

            ExitKey = "q";
            ReplayKey = "1";

            Problem = new Problem();
            Player = new Player();
            Referee = new Referee();

            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            Problem.Initialize();
            Player.Initialize();

            ShowExplanationMessage();
        }

        /// <summary>
        /// ゲームの説明文を表示する
        /// </summary>
        private void ShowExplanationMessage()
        {
            Console.Clear();
            Console.WriteLine($"{Problem.NumberRange}の数値を入力し当ててください。");
            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");
        }

        /// <summary>
        /// メインループ
        /// </summary>
        public void Run()
        {
            while(true)
            {
                Player.Input();

                if(Player.IsNumber)
                {
                    var result = Referee.Judge(Player.InputNumber, Problem.UnknownNumber);
                    Referee.ShowMessage(result);

                    if(result == Referee.JudgmentResult.Equal)
                    {
                        Replay();
                    }
                }
                else if(Player.InputValue == ExitKey)
                {
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// 正解後に再度ゲームをプレイするか問う
        /// </summary>
        public void Replay()
        {
            Console.WriteLine($"もう1度プレイされるなら {ReplayKey} を入力してください。");

            Player.Input();

            if(Player.InputValue == ReplayKey)
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
