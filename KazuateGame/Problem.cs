using System;

namespace KazuateGame
{
    /// <summary>
    /// 問題
    /// 数当てゲームの問題となる当てる数を扱う
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// 定数
        /// </summary>
        public readonly int RandomMinValue;
        public readonly int RandomMaxValue;
        public readonly int DisplayMaxValue;
        public readonly string ValueRange;


        public int UnknownValue { get; private set; }

        public Problem()
        {
            RandomMinValue = 1;
            RandomMaxValue = 100 + 1;                               // + 1 をしないと99までしか得られない
            DisplayMaxValue = RandomMaxValue - 1;                   // RandomMaxValue が + 1 で表示するので表示用を別に用意
            ValueRange = $"{RandomMinValue}～{DisplayMaxValue}"; 

            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            var random = new Random(DateTime.Now.Second);
            UnknownValue = random.Next(RandomMinValue, RandomMaxValue);
        }
    }
}
