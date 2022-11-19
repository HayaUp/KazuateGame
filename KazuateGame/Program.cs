﻿using System;

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

            Console.WriteLine("1～100の数値を入力し当ててください。");
            Console.WriteLine("q を入力するとゲームを終了します。");

            while(true)
            {
                var input_value = Console.ReadLine();

                if(input_value == "q")
                {
                    break;
                }
            }
        }
    }
}
