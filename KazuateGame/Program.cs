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

            Console.WriteLine("1～100の数値を入力し当ててください。");
            Console.WriteLine("q を入力するとゲームを終了します。");

            while(true)
            {
                var input_value = Console.ReadLine();

                if(input_value == "q")
                {
                    Console.WriteLine("ゲームを終了します。");
                    break;
                }

                var input_number = 0;

                // 入力は数値が前提だけど英字等が入力される可能性もある
                if(int.TryParse(input_value, out input_number))
                {
                    if(input_number == unknown_value)
                    {
                        Console.WriteLine("正解です！");
                        Console.ReadLine();
                        break;
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
