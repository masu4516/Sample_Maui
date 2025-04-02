using Sample_Maui.Controls;
using Microsoft.Maui.Handlers;
using Android.Widget;
using Android.App;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Platform;
using Sample_Maui.Handlers;


namespace Sample_Maui.Platforms.Android.Handlers
{

    /// <summary>
    /// ViewHandler<TVirtualView, TNativeView>
    /// TVirtualView：共通部のコントロール(VirtualView)
    /// TNativeView:プラットフォーム固有のコントロール(PlatformView)
    /// </summary>
    public partial class CustomLabelHandler : ViewHandler<CustomLabel, AppCompatTextView>
    {
        //引数違いのコンストラクタ
        public CustomLabelHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }
        
        /// <summary>
        /// 継承にあたり必須のオーバーライド。ここでAndroidのコントロール（実画面）を生成する
        /// </summary>
        /// <returns></returns>
        protected override AppCompatTextView CreatePlatformView()
        {
            //共通部のコントロールを取得
            var virtualView = this.VirtualView;
            //AndroidのTextViewを生成
            var textView = new AppCompatTextView(MainActivity.Instance);

            /*if (virtualView.Text!=null)
            {
                textView.Text = virtualView.Text;
            }*/

            // Xamarinのコントロールで設定したFontSizeを取得
            //var size = virtualView.FontSize;
            // 単位dpで設定し直す
            //textView.SetTextSize(ComplexUnitType.Dip, (float)size);

            return textView;
        }
        protected override void ConnectHandler(AppCompatTextView platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any control setup here
        }

        protected override void DisconnectHandler(AppCompatTextView platformView)
        {
            // Perform any native view cleanup here
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        //staticメソッドで、プロパティの変更を受け取り、プラットフォーム固有のコントロールに反映する
        public static void MapText(CustomLabelHandler handler, CustomLabel view)
        {
            handler.PlatformView.Text = view.Text;
            //handler.PlatformView?.SetSelection(handler.PlatformView?.Text?.Length ?? 0);
        }

        public static void MapTextColor(CustomLabelHandler handler, CustomLabel view)
        {
            handler.PlatformView?.SetTextColor(view.TextColor.ToPlatform());
        }

        public static void MapFontSize(CustomLabelHandler handler, CustomLabel view)
        {
            handler.PlatformView?.SetTextSize(ComplexUnitType.Dip, (float)view.FontSize);
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
