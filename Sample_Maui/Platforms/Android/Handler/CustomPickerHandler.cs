using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Sample_Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Lang.Reflect;
using Paint = Android.Graphics.Paint;
using Font = Microsoft.Maui.Font;
using Microsoft.Maui.Controls.Platform;
using Android.Graphics.Drawables;
using Sample_Maui.Controls;
using Sample_Maui;

namespace Sample_Maui.Handlers
{
    public partial class CustomPickerHandler
    {
        public static PropertyMapper<PickerView, CustomPickerHandler> PropertyMapper = new PropertyMapper<PickerView, CustomPickerHandler>(ViewHandler.ViewMapper)
        {

        };

        public CustomPickerHandler() : base(PropertyMapper)
        {
        }
    }


    public partial class CustomPickerHandler : ViewHandler<PickerView, NumberPicker>
    {
        public CustomPickerHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        protected override NumberPicker CreatePlatformView()
        {
            List<string> arr = new List<string>();
            NumberPicker n = new NumberPicker(MainActivity.Instance);

            Font font = string.IsNullOrEmpty(this.VirtualView.FontFamily) ?
                Font.SystemFontOfSize(this.VirtualView.FontSize) :
                Font.OfSize(this.VirtualView.FontFamily, this.VirtualView.FontSize);

            SetTextSize(n, font, (float)(this.VirtualView.FontSize * Context.Resources.DisplayMetrics.Density));

            if (this.VirtualView.ItemsSource != null)
            {
                foreach (var item in this.VirtualView.ItemsSource)
                {
                    arr.Add(item.ToString());
                }
            }

            if (arr.Count > 0)
            {
                int newMax = arr.Count - 1;
                if (newMax < n.Value)
                {
                    this.VirtualView.SelectedIndex = newMax;
                }

                var extend = n.MaxValue <= newMax;

                if (extend)
                {
                    n.SetDisplayedValues(arr.ToArray());
                }

                n.MaxValue = newMax;
                n.MinValue = 0;

                if (!extend)
                {
                    n.SetDisplayedValues(arr.ToArray());
                }
            }
            n.Value = this.VirtualView.SelectedIndex;

            n.MaxValue = arr.Count - 1;
            n.MinValue = 0;
            n.SetDisplayedValues(arr.ToArray<String>());
            n.ValueChanged += (sender, e) => {
                this.VirtualView.SelectedIndex = e.NewVal;
            };
            if (n != null)
            {
                // 枠線を消す
                GradientDrawable gd = new GradientDrawable();

                //this line sets the bordercolor
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                n.SetBackground(gd);
            }

            return n;
        }

        /// <summary>
        /// NumberPicker の文字サイズを変更するハック
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/22962075/change-the-text-color-of-numberpicker"/>
        /// <param name="numberPicker">Number picker.</param>
        /// <param name="textSizeInSp">Text size in pixel.</param>

        private static void SetTextSize(NumberPicker numberPicker, Font fontFamily, float textSizeInSp)
        {
            int count = numberPicker.ChildCount;


            for (int i = 0; i < count; i++)
            {
                var child = numberPicker.GetChildAt(i);
                var editText = child as EditText;

                if (editText != null)
                {
                    try
                    {
                        Field selectorWheelPaintField = numberPicker.Class.GetDeclaredField("mInputText");
                        selectorWheelPaintField.Accessible = true;
                        ((Paint)selectorWheelPaintField.Get(numberPicker)).TextSize = textSizeInSp;
                        //editText.Typeface = fontFamily.ToTypeface();
                        editText.SetTextSize(ComplexUnitType.Px, textSizeInSp);
                        numberPicker.Invalidate();
                    }
                    catch (System.Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("SetNumberPickerTextColor failed.", e);
                    }
                }
            }
        }

    }
}
