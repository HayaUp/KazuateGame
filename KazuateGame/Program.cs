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

            var random = new Random(DateTime.Now.Second);

            var unknown_value = random.Next(1, 101);
            Console.WriteLine(unknown_value);
        }
    }
}
