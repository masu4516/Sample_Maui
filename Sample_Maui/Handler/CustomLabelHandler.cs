#if IOS
using PlatformView = Microsoft.Maui.Platform.MauiTextField;
#elif ANDROID
using PlatformView = AndroidX.AppCompat.Widget.AppCompatTextView;
#endif

using Sample_Maui.Controls;
using Microsoft.Maui.Handlers;


namespace Sample_Maui.Handlers
{
    public partial class CustomLabelHandler
    {
        //ここは継承しないとエラーになる。ディクショナリに string-Action のペアを追加している
        //これによりテキストや色が変更されたときに、それぞれのActionが呼ばれる
        public static PropertyMapper<CustomLabel, CustomLabelHandler> PropertyMapper = 
            new PropertyMapper<CustomLabel, CustomLabelHandler>(ViewHandler.ViewMapper)
            {
                [nameof(CustomLabel.Text)] = MapText,
                [nameof(CustomLabel.TextColor)] = MapTextColor,
                [nameof(CustomLabel.FontSize)] = MapFontSize
            };

        //コンストラクタ（base：継承元のコンストラクタを呼び出す）
        public CustomLabelHandler() : base(PropertyMapper)
        {
        }
    }
}

