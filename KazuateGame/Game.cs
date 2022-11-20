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
        public enum JudgmentResultStatus
        {
            Unknown,
            Equal,
            Small,
            Big
        }

        public int UnknownValue { get; private set; }
        private JudgmentResultStatus judgmentResult;

        public Game()
        {
            RandomMinValue = 1;
            RandomMaxValue = 100 + 1;                  // + 1 をしないと99までしか得られない
            DisplayMaxValue = RandomMaxValue - 1;      // RandomMaxValue が + 1 で表示するので表示用を別に用意
            ExitKey = "q";
            ReplayKey = "1";

            Reset();
        }

        /// <summary>
        /// 特定の範囲の値や判定結果を初期化する
        /// </summary>
        private void Reset()
        {
            var random = new Random(DateTime.Now.Second);
            UnknownValue = random.Next(RandomMinValue, RandomMaxValue);

            judgmentResult = JudgmentResultStatus.Unknown;
        }

        /// <summary>
        /// ゲームの説明文を表示する
        /// </summary>
        public void ShowExplanationMessage()
        {
            Console.Clear();
            Console.WriteLine($"{RandomMinValue}～{DisplayMaxValue}の数値を入力し当ててください。");
            Console.WriteLine($"{ExitKey} を入力するとゲームを終了します。");
        }

        /// <summary>
        /// 入力値と特定の範囲の値を比較し判定する
        /// </summary>
        /// <param name="input_value">入力値</param>
        /// <returns>判定内容</returns>
        public void Judge(string input_value)
        {
            // 入力は数値が前提だけど英字等が入力される可能性もある
            if(int.TryParse(input_value, out int input_number))
            {
                if(input_number == UnknownValue)
                {
                    judgmentResult = JudgmentResultStatus.Equal;
                }
                else if(input_number < UnknownValue)
                {
                    judgmentResult = JudgmentResultStatus.Small;
                }
                else if(input_number > UnknownValue)
                {
                    judgmentResult = JudgmentResultStatus.Big;
                }
            }
            else if(input_value == ExitKey)
            {
                Environment.Exit(0);
            }
            else
            {
                judgmentResult = JudgmentResultStatus.Unknown;
            }
        }

        /// <summary>
        /// 判定内容によって判定結果を表示する
        /// </summary>
        /// <param name="result">判定結果</param>
        public void ShowJudgmentMessage()
        {
            if(judgmentResult == JudgmentResultStatus.Equal)
            {
                Console.WriteLine("正解です！");
                Console.WriteLine($"もう1度プレイされるなら {ReplayKey} を入力してください。");

                var input_value = Console.ReadLine();

                if(input_value == ReplayKey)
                {
                    ShowExplanationMessage();
                    Reset();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if(judgmentResult == JudgmentResultStatus.Small)
            {
                Console.WriteLine("入力値は小さいです。");
            }
            else if(judgmentResult == JudgmentResultStatus.Big)
            {
                Console.WriteLine("入力値は大きいです。");
            }
        }
    }
}
