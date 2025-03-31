using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Collections;

namespace Sample_Maui.Controls
{
    public class PickerView : View
    {
        /// <summary>
        /// ItemSource
        /// </summary>
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
    typeof(IEnumerable), typeof(PickerView), null);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// SelectedIndex
        /// </summary>
        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PickerView), -1, BindingMode.TwoWay,
                coerceValue: CoerceSelectedIndex);


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        private static object CoerceSelectedIndex(BindableObject bindable, object value)
        {
            if (value == null)
            {
                return 0;
            }
            return value;
        }

        /// <summary>
        /// FontSize
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(PickerView), -1.0,
       defaultValueCreator: bindable => // TODO Xamarin.Forms.Device.GetNamedSize is not longer supported. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
Device.GetNamedSize(NamedSize.Default, (PickerView)bindable),
       coerceValue: CoerceFontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        private static object CoerceFontSize(BindableObject bindable, object value)
        {
            if (value == null)
            {
                // TODO Xamarin.Forms.Device.GetNamedSize is not longer supported. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                return Device.GetNamedSize(NamedSize.Default, (PickerView)bindable);
            }
            return value;
        }

        /// <summary>
        /// FontFamily
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(PickerView), default(string));

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
    }
}