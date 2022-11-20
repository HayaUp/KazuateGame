using System;

namespace KazuateGame
{
    class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "数当てゲーム";

            var game = new Game();

            // ゲームのループ
            while(true)
            {
                // キー入力
                var input_value = Console.ReadLine();

                game.Judge(input_value);
                game.ShowJudgmentMessage();
            }
        }
    }
}
