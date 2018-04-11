using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BoardGame.ViewModel;

namespace BoardGame.Model
{
    class BlackJackLogic : BaseLogic
    {
        public void PlayBlackJack()
        {
            var Player = new BlackJackViewModel();
            var Dealer = new BlackJackViewModel();
            var Table = new BlackJackLogic();


        }



        /// <summary>
        /// 勝敗を判定するメソッド（インターフェースの実装）
        /// </summary>
        /// <param name="player">プレイヤーのスコア</param>
        /// <param name="dealer">ディーラーのスコア</param>
        /// <returns></returns>
        public string WinOrLose(int player, int dealer)
        {
            string message;
            if (player > dealer)
            {
                message = "プレイヤーの勝ちです";
            }
            else if (player < dealer)
            {
                message = "ディーラーの勝ちです";
            }
            else
            {
                message = "引き分けです";
            }

            return message;

        }
        /// <summary>
        /// ブラックジャックのカードを引くメソッド
        /// </summary>
        /// <param name="result">2回目以降に対応するため引数で前回の結果を取得</param>
        /// <returns></returns>
        private BlackJackViewModel TakeCard(BlackJackViewModel result)
        {
            // 変数の初期化
            var Result = new BlackJackViewModel();
            Result.Cards = new List<int>();

            // 2回目か判定
            if (result.Cards.Count() > 0)
                Result = result;

            // ループ文でListに数を追加
            do
            {
                Result.Cards.Add(GiveCardNumber());
            } while (Result.Cards.Count() < 2);

            // 格納した数を拡張for文で合計スコアの計算
            foreach (var c in Result.Cards)
            {
                Result.Score += c;
            }

            // 21より大きければ例外をThrow
            if (Result.Score > 21)
                throw new BoardGameException("バーストしました");

            Thread.Sleep(1000);
            return Result;
        }

        /// <summary>
        /// 乱数生成（private）
        /// </summary>
        /// <returns>Random.Next処理のみ</returns>
        private int GiveCardNumber()
        {
            var Tramp = new Random();
            var t = Tramp.Next(0, 11);
            return t;
        }
    }
}
