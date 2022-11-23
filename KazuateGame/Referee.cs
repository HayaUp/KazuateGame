using System;

namespace KazuateGame
{
    /// <summary>
    /// 審判・判定者
    /// </summary>
    public class Referee
    {
        // 入力値と不明値の判定結果
        public enum JudgmentResult
        {
            Unknown,
            Equal,
            Small,
            Big
        }

        /// <summary>
        /// 入力値と不明値を判定する
        /// </summary>
        /// <param name="input_number">入力値</param>
        /// <param name="unknown_number">不明値</param>
        /// <returns>比較した結果</returns>
        public JudgmentResult Judge(int input_number, int unknown_number)
        {
            if(input_number == unknown_number)
            {
                return JudgmentResult.Equal;
            }
            else if(input_number < unknown_number)
            {
                return JudgmentResult.Small;
            }
            else if(input_number > unknown_number)
            {
                return JudgmentResult.Big;
            }

            return JudgmentResult.Unknown;
        }

        /// <summary>
        /// 判定結果に応じたメッセージを表示する
        /// </summary>
        /// <param name="result"></param>
        public void ShowMessage(JudgmentResult result)
        {
            var message = "";

            if(result == JudgmentResult.Equal)
            {
                message = "正解です！";
            }
            else if(result == JudgmentResult.Small)
            {
                message = "入力値は小さいです。";
            }
            else if(result == JudgmentResult.Big)
            {
                message = "入力値は大きいです。";
            }
            else
            {
                message = "入力は無効です。";
            }

            Console.WriteLine(message);
        }
    }
}
