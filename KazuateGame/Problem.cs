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
        public readonly int RandomMinNumber;
        public readonly int RandomMaxNumber;
        public readonly int DisplayMaxNumber;
        public readonly string NumberRange;

        public int UnknownNumber { get; private set; }

        public Problem()
        {
            RandomMinNumber = 1;
            RandomMaxNumber = 100 + 1;                                  // + 1 をしないと99までしか得られない
            DisplayMaxNumber = RandomMaxNumber - 1;                     // RandomMaxNumber が + 1 で表示するので表示用を別に用意
            NumberRange = $"{RandomMinNumber}～{DisplayMaxNumber}"; 

            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            var random = new Random(DateTime.Now.Second);
            UnknownNumber = random.Next(RandomMinNumber, RandomMaxNumber);
        }
    }
}
