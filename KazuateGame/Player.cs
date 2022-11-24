using System;

namespace KazuateGame
{
    /// <summary>
    /// 入力した内容を扱う
    /// </summary>
    public class Player
    {
        public string InputValue { get; private set; }
        public int InputNumber { get; private set; }
        public bool IsNumber { get; private set; }          // 入力値が数値であれば true

        public Player()
        {
            Initialize();
        }

        public void Initialize()
        {
            InputValue = "";
            InputNumber = 0;
            IsNumber = false;
        }

        /// <summary>
        /// 文字列入力、文字列を数値への変換、数値判定を行う
        /// </summary>
        public void Input()
        {
            InputValue = Console.ReadLine();

            IsNumber = int.TryParse(InputValue, out int input_value);

            if(IsNumber)
            {
                InputNumber = input_value;
            }
        }
    }
}
