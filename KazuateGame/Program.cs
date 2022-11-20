using System;

namespace KazuateGame
{
    class Program
    {
        const int RandomMinValue        = 1;
        const int RandomMaxValue        = 100 + 1;      // + 1 をしないと99までしか得られない
        const string DisplayMaxValue    = "100";        // RandomMaxValue が + 1 で表示するので表示用を別に用意
        const string ExitKey            = "q";
        const string ReplayKey          = "1";

        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "数当てゲーム";

            var game = new Game();

            // 乱数の取得
            var random = new Random(DateTime.Now.Second);
            var unknown_value = random.Next(RandomMinValue, RandomMaxValue);

            // ゲームの説明文
            game.ShowExplanatoryText();

            // ゲームのループ
            while(true)
            {
                // キー入力
                var input_value = Console.ReadLine();

                game.Exit(input_value);

                var input_number = 0;

                // 入力は数値が前提だけど英字等が入力される可能性もある
                if(int.TryParse(input_value, out input_number))
                {
                    // 正解、不正解(大きい、小さい)
                    if(input_number == unknown_value)
                    {
                        Console.WriteLine("正解です！");
                        Console.WriteLine($"もう1度プレイされるなら {ReplayKey} を入力してください。");

                        // リプレイ
                        if(Console.ReadLine() == ReplayKey)
                        {
                            game.ShowExplanatoryText();
                            unknown_value = random.Next(RandomMinValue, RandomMaxValue);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if(input_number > unknown_value)
                    {
                        Console.WriteLine($"{input_number}は大きいです。");
                    }
                    else if(input_number < unknown_value)
                    {
                        Console.WriteLine($"{input_number}は小さいです。");
                    }
                }
            }
        }
    }
}
