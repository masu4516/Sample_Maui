using Sample_Maui.Controls;
using Microsoft.Maui.Handlers;
using Android.Widget;
using Android.App;

namespace Sample_Maui.Platforms.Handlers
{
    public partial class MyPickerHandler
    {
        public static PropertyMapper<PickerView, MyPickerHandler> PropertyMapper = new PropertyMapper<PickerView, MyPickerHandler>(ViewHandler.ViewMapper)
        {

        };

        public MyPickerHandler() : base(PropertyMapper)
        {
        }
    }

    public partial class MyPickerHandler : ViewHandler<MyPicker, EditText>
    {
        protected override EditText CreatePlatformView()
        {
            var edit = new EditText(MainActivity.Instance);
            edit.Focusable = false;
            edit.FocusableInTouchMode = false;
            edit.Click += (s, e) =>
            {
                var p = this.VirtualView as Picker;
                var items = p.ItemsSource as IList<string>;

                var n = new NumberPicker(MainActivity.Instance);

                n.MaxValue = items.Count - 1;
                n.MinValue = 0;
                n.SetDisplayedValues(items.ToArray<string>());
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(MainActivity.Instance);
                var dlg = alertDialog.SetTitle(p.Title)
                .SetView(n)
                .SetPositiveButton("OK", (s, e) =>
                {

                    edit.Text = p.ItemsSource[n.Value].ToString(); // Assign the selected value to EditText
                })
                .Create();
                dlg.Show();
            };
            return edit;
        }
    }
}