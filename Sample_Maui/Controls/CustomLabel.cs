using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Collections;
using Java.Net;

namespace Sample_Maui.Controls
{
    public class CustomLabel : View
    {
        /// <summary>
        /// Textプロパティを作成
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                    propertyName: nameof(Text),  //紐づけるプロパティ名
                    returnType: typeof(string),  //プロパティの型
                    declaringType: typeof(CustomLabel),  //このプロパティを持つクラス
                    defaultValue: default(string)  //デフォルト値
            );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// TextColorプロパティを作成
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
                    propertyName: nameof(TextColor),
                    returnType: typeof(Color),
                    declaringType: typeof(CustomLabel),
                    defaultValue: Colors.Black
            );

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        /// <summary>
        ///FontSizeプロパティを作成
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                    propertyName: nameof(FontSize),
                    returnType: typeof(double),
                    declaringType: typeof(CustomLabel),
                    defaultValue: 10.0
            );

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        


    }
}