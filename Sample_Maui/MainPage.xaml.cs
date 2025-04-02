using Microsoft.Maui.Graphics.Text;
using RGPopup.Maui.Extensions;
using Sample_Maui.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample_Maui
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        int count = 0;
        private PopupPicker popup_page;

        public MainPage()
        {
            InitializeComponent();
            ModifyEntry();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        //ボタン2を押した時の処理
        async void OnPopupClicked(object sender, EventArgs e)
        {
            label1.TextColor = Colors.Orange;
            label2.TextColor = Colors.Orange;
            
            /*popup_page = new PopupPicker();
             Navigation.PushAsync(popup_page, true);*/
            //Microsoft.Maui.Handlers.LabelHandler.Mapper.ModifyMapping(nameof(ILabel.TextColor), (handler, view, element) =>
            //Microsoft.Maui.Handlers.LabelHandler.Mapper.PrependToMapping(nameof(ILabel.TextColor), (handler, view) =>
            //Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping(nameof(ILabel.TextColor), (handler, view) =>
            Microsoft.Maui.Handlers.LabelHandler.Mapper.PrependToMapping("MyCustomization", (handler, view) =>
            {
                if (view is Label)
                {
#if ANDROID
                    handler.PlatformView.SetSelectAllOnFocus(true);
                    label2.TextColor = Colors.Red;
#elif IOS
                    handler.PlatformView.TextColor = UIColor.Red;
#endif
                }
            });

        }

        //ピッカーから選択時に実行
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                pickLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

        //ピッカー作成後に呼び出し
        void ModifyEntry()
        {
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
                if (view is MyPicker)
                {
#if ANDROID
                    handler.PlatformView.SetSelectAllOnFocus(true);
#endif
                }
            });
        }
    }

}
