using Newtonsoft.Json;
using Sample_Maui.Models.Provider.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace Sample_Maui.Provider.Http
{
    /// <summary>
    /// HTTP通信送信クラス
    /// </summary>
    public class HttpSendProvider
    {
        /// <summary>
        /// HTTP通信送信 パラメータのJSON文字列をPOST　戻り値をJSON文字列で取得する
        /// </summary>
        /// <param name="url">リクエストURL(ホストなし)</param>
        /// <param name="postData">リクエストパラメータ</param>
        /// <returns></returns>
        public async Task<HttpResModel> PostHttpRequest(string url, Dictionary<string, string> postData)
        {
            HttpResponseMessage response = null;
            HttpResModel model = new HttpResModel();

            //postData=nullの場合、ダミーデータをpostするようにする
            if (postData == null)
            {
                postData = new Dictionary<string, string>()
                {
                    { "NoData", "Dummy" }
                };
            }

            using (var client = new HttpClient())
            {
                // 初期化を設定
                client.Timeout = TimeSpan.FromMilliseconds(60000);   // タイムアウト60秒

                // リクエストデータの設定
                var data = JsonConvert.SerializeObject(postData);
                try
                {
                    // APIを呼び出す
                    var content = new StringContent(data, Encoding.UTF8, "application/json");

                    //パラメータ設定が不要な場合はダミーデータを送る。nullを送るとエラーになる。
                    response = client.PostAsync(url, content).Result;

                    if (null != response)
                    {
                        // コードの状態をチェック
                        if (response.IsSuccessStatusCode)
                        {
                            // レスポンスがOKの場合
                            model.Result = response.IsSuccessStatusCode;
                            // レスポンスの結果を処理する
                            string jsonString = await response.Content.ReadAsStringAsync();
                            model.json = jsonString;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                return model;
            }
        }

        /// <summary>
        /// HTTP通信送信 パラメータのJSON文字列をPOST　戻り値をJSON文字列で取得する（ヘルスチェック用）
        /// </summary>
        /// <param name="url">リクエストURL(ホストなし)</param>
        /// <param name="postData">リクエストパラメータ</param>
        /// <returns></returns>
        public async Task<HttpResModel> PostHttpHealthRequest(string url, Dictionary<string, string> postData)
        {
            HttpResponseMessage response = null;
            HttpResModel model = new HttpResModel();

            //postData=nullの場合、ダミーデータをpostするようにする
            if (postData == null)
            {
                postData = new Dictionary<string, string>()
                {
                    { "NoData", "Dummy" }
                };
            }

            using (var client = new HttpClient())
            {
                // 初期化を設定
                client.Timeout = TimeSpan.FromMilliseconds(10000);   // タイムアウト10秒（ヘルスチェックは通常より短くする）

                // リクエストデータの設定
                string data = JsonConvert.SerializeObject(postData);
                try
                {
                    // APIを呼び出す
                    var content = new StringContent(data, Encoding.UTF8, "application/json");

                    //パラメータ設定が不要な場合はダミーデータを送る。nullを送るとエラーになる。
                    response = client.PostAsync(url, content).Result;

                    if (null != response)
                    {
                        // コードの状態をチェック
                        if (response.IsSuccessStatusCode)
                        {
                            // レスポンスがOKの場合
                            model.Result = response.IsSuccessStatusCode;
                            // レスポンスの結果を処理する
                            string jsonString = await response.Content.ReadAsStringAsync();
                            model.json = jsonString;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                return model;
            }
        }

        /// <summary>
        /// クエリパラメータの文字列を作成する
        /// </summary>
        /// <param name="postData">パラメータマップ</param>
        /// <returns></returns>
        public static string CreateQueryParam(Dictionary<string, string> dataMap)
        {
            if (null == dataMap)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string, string> pair in dataMap)
            {
                if (!first)
                {
                    sb.Append("&");
                }
                else
                {
                    sb.Append("?");
                }

                sb.AppendFormat("{0}={1}", Uri.EscapeDataString(pair.Key), Uri.EscapeDataString(pair.Value));

                first = false;
            }
            return sb.ToString();
        }
    }
}
