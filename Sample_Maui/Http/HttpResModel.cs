using System;

namespace Sample_Maui.Http
{
    /// <summary>
    /// HTTPレスポンスモデルクラス
    /// </summary>
    public class HttpResModel
    {
        // 処理結果 (true:正常 false:異常)
        public Boolean Result { get; set; }

        // レスポンスJSON文字列
        public string json { get; set; }

    }
}
