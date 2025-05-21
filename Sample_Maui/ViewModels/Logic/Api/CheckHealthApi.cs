using Sample_Maui.Models.Provider.Http;
using Sample_Maui.Provider.Http;

namespace Sample_Maui.ViewModels.Logic.Api
{
    class CheckHealthApi
    {
        /// <summary>
        /// APIヘルスチェック処理
        /// 他のアプリ連携フラグ取得のAPIの応答有無で確認する
        /// </summary>
        /// <returns>チェック結果　true/false</returns>
        public bool Check()
        {
            bool ret = false;
            string url = "";

            int env = 1;
            // URL作成
            switch (env)
            {
                case 0:            // 本番環境の場合
                    url = "https://rmserv.aztower.net/ppsrcapi/"; // ホスト
                    break;
                case 1:           // デモ環境の場合
                    url = "https://rmserv.aztower.net/ppsrcapi_test/";    // ホスト
                    break;
            }

            // URL作成 ホスト＋サブURL
            url = url + "sp/link_state";

            //API連携
            HttpSendProvider httpSendProvider = new HttpSendProvider();
            HttpResModel result = httpSendProvider.PostHttpHealthRequest(url, null).Result;
            if (null != result && result.Result && !string.IsNullOrEmpty(result.json))
            {
                //JSONデータが取得できた
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// アクセスログからデバッグ用
        /// </summary>
        /// <param name="info"></param>
        public static void Log(string info)
        {
            string url = "https://rmserv.aztower.net/ppsrcapi_test/link/operation/login?debug="
                       + info;
            //API連携
            HttpSendProvider httpSendProvider = new HttpSendProvider();
            HttpResModel result = httpSendProvider.PostHttpHealthRequest(url, null).Result;
            if (null != result && result.Result && !string.IsNullOrEmpty(result.json))
            {
            }
        }

    }

}
