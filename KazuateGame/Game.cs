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

        // 入力値と特定の範囲の値の判定結果
        public enum JudgmentResult
        {
            Unknown,
            Equal,
            Small,
            Big
        }

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

        /// <summary>
        /// 入力値と特定の範囲の値を比較し判定する
        /// </summary>
        /// <param name="input_value">入力値</param>
        /// <returns>判定内容</returns>
        public JudgmentResult Judge(string input_value)
        {
            // 入力は数値が前提だけど英字等が入力される可能性もある
            if(int.TryParse(input_value, out int input_number))
            {
                if(input_number == UnknownValue)
                {
                    return JudgmentResult.Equal;
                }
                else if(input_number < UnknownValue)
                {
                    return JudgmentResult.Small;
                }
                else if(input_number > UnknownValue)
                {
                    return JudgmentResult.Big;
                }
            }

            return JudgmentResult.Unknown;
        }

        /// <summary>
        /// 判定内容によって判定結果を表示する
        /// </summary>
        /// <param name="result">判定結果</param>
        public void ShowJudgmentMessage(JudgmentResult result)
        {
            if(result == JudgmentResult.Equal)
            {
                Console.WriteLine("正解です！");
                Console.WriteLine($"もう1度プレイされるなら {ReplayKey} を入力してください。");

                var input_value = Console.ReadLine();

                if(input_value == ReplayKey)
                {
                    ShowExplanatoryText();
                    ResetUnknownValue();
                }
                else
                {
                    Exit(ExitKey);
                }
            }
            else if(result == JudgmentResult.Small)
            {
                Console.WriteLine("入力値は小さいです。");
            }
            else if(result == JudgmentResult.Big)
            {
                Console.WriteLine("入力値は大きいです。");
            }
        }
    }
}
