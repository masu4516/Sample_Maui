

namespace Sample_Maui.Models.Provider
{
    /// <summary>
    /// 通信モデルクラスの既定クラス
    /// </summary>
    public class BaseProviderModel
    {
        //環境変数(2:develop/1:release/0:master)を格納
        private readonly int envMode = 1;  //nnn
        // -------------------------------
        // INPUT
        // -------------------------------
        // リトライ回数　デフォルト5回
        private int __retryCnt;
        // 通信タイムアウト(ミリ秒)　デフォルト5秒
        private int __receiveTimeout;
        // リトライ待機(ミリ秒)　デフォルト1秒
        private int __retryWait;
        // 送信先 ホストIP
        public string Host { get; set; }
        // 送信先 ポート番号
        public int Port { get; set; }

        // 通信タイムアウト本番環境以外は３秒をセット
        public int ReceiveTimeout
        {
            get { return __receiveTimeout; }
            set
            {
                __receiveTimeout = 0 == envMode ? value : 3000;
            }
        }
        // リトライ回数本番環境以外は１回セット
        public int RetryCnt {
            get { return __retryCnt; }
            set
            {
                __retryCnt = 0 == envMode ? value : 1;
            }
        }
        // リトライ待機本番環境以外は0をセット
        public int RetryWait
        {
            get { return __retryWait; }
            set
            {
                __retryWait = 0 == envMode ? value : 0;
            }
        }

        // 
        // -------------------------------
        // OUTPUT
        // -------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseProviderModel()
        {
            // 初期化
            ReceiveTimeout = 5000; //nnn
            RetryCnt = 5;
            RetryWait = 10000;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="envMode">環境変数(2:develop/1:release/0:master)</param>
        public BaseProviderModel(int envMode)
        {
            this.envMode = envMode;
            // 初期化
            ReceiveTimeout = 5000; //nnn;
            RetryCnt = 5;
            RetryWait = 10000;
        }
    }
}
