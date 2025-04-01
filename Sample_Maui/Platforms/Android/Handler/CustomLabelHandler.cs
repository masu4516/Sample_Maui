using Sample_Maui.Controls;
using Microsoft.Maui.Handlers;
using Android.Widget;
using Android.App;
using Android.Util;


namespace Sample_Maui.Platforms.Android.Handlers
{
    public partial class CustomLabelHandler
    {
        //ここは継承しないとエラーになる
        public static PropertyMapper<CustomLabel, CustomLabelHandler> PropertyMapper = new PropertyMapper<CustomLabel, CustomLabelHandler>(ViewHandler.ViewMapper)
        {

        };

        //コンストラクタ（base：継承元のコンストラクタを呼び出す）
        public CustomLabelHandler() : base(PropertyMapper)
        {
        }
    }

    public partial class CustomLabelHandler : ViewHandler<CustomLabel, TextView>
    {
        //引数違いのコンストラクタ
        public CustomLabelHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        //継承にあたり必須のオーバーライド
        protected override TextView CreatePlatformView()
        {
            var textView = new TextView(MainActivity.Instance);
            // Xamarinのコントロールで設定したFontSizeを取得
            var size = textView.TextSize;
            textView.Text = "Comon";

            textView.SetTextSize(ComplexUnitType.Dip, (float)size);
            return textView;
        }
    }
}

/*
public class CustomLabelHandler : LabelHandler
{
    public CustomLabelHandler(Context context) : base(context)
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
        base.OnElementChanged(e);

        // Xamarinのコントロールで設定したFontSizeを取得
        var size = Element.FontSize;
        // 単位dpで設定し直す
        Control.SetTextSize(ComplexUnitType.Dip, (float)size);
    }
}*/
