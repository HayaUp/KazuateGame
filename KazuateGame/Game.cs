using System;
using System.Collections.Generic;
using System.Text;

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

        public int UnknownValue { get; private set; }

        public Game()
        {
            RandomMinValue = 1;
            RandomMaxValue = 100 + 1;                  // + 1 をしないと99までしか得られない
            DisplayMaxValue = RandomMaxValue - 1;      // RandomMaxValue が + 1 で表示するので表示用を別に用意
            ExitKey = "q";
            ReplayKey = "1";

            ResetUnknownValue();
        }

        /// <summary>
        /// ゲームの説明文を表示する
        /// </summary>
        public void ShowExplanatoryText()
        {
            Console.Clear();
            Console.WriteLine($"{RandomMinValue}～{DisplayMaxValue}の数値を入力し当ててください。");
            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");
        }

        /// <summary>
        /// 特定のキーを押したらゲームを終了する
        /// </summary>
        /// <param name="input_key"></param>
        /// <returns></returns>
        public void Exit(string input_key)
        {
            if(input_key == ExitKey)
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 特定の範囲の値を設定する
        /// </summary>
        private void ResetUnknownValue()
        {
            var random = new Random(DateTime.Now.Second);
            UnknownValue = random.Next(RandomMinValue, RandomMaxValue);
        }
    }
}
