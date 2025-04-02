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
        public static PropertyMapper<Label, CustomLabelHandler> PropertyMapper = 
            new PropertyMapper<Label, CustomLabelHandler>(ViewHandler.ViewMapper)
        {

        };

        //コンストラクタ（base：継承元のコンストラクタを呼び出す）
        public CustomLabelHandler() : base(PropertyMapper)
        {
        }
    }

    /// <summary>
    /// ViewHandler<TVirtualView, TNativeView>
    /// TVirtualView：共通部のコントロール(VirtualView)
    /// TNativeView:プラットフォーム固有のコントロール(PlatformView)
    /// </summary>
    public partial class CustomLabelHandler : ViewHandler<Label, TextView>
    {
        //引数違いのコンストラクタ
        public CustomLabelHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        /// <summary>
        /// 継承にあたり必須のオーバーライド。ここでAndroidのコントロール（実画面）を生成する
        /// </summary>
        /// <returns></returns>
        protected override TextView CreatePlatformView()
        {
            //共通部のコントロールを取得
            var virtualView = this.VirtualView;
            //AndroidのTextViewを生成
            var textView = new TextView(MainActivity.Instance);

            if (virtualView.Text!=null)
            {
                textView.Text = virtualView.Text;
            }

            // Xamarinのコントロールで設定したFontSizeを取得
            var size = virtualView.FontSize;
            // 単位dpで設定し直す
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
