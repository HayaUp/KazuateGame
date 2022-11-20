﻿using System;

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

            // 乱数の取得
            var random = new Random(DateTime.Now.Second);
            var unknown_value = random.Next(RandomMinValue, RandomMaxValue);

            // ゲームの説明文
            Console.WriteLine($"{RandomMinValue}～{DisplayMaxValue}の数値を入力し当ててください。");
            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");

            // ゲームのループ
            while(true)
            {
                // キー入力
                var input_value = Console.ReadLine();

                if(input_value == ExitKey)
                {
                    Console.WriteLine("ゲームを終了します。");
                    break;
                }

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
                            Console.Clear();
                            Console.WriteLine($"{RandomMinValue}～{DisplayMaxValue}の数値を入力し当ててください。");
                            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");
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
