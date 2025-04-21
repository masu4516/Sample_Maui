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
            // ピッカーに値設定
            CreateItem();

            // 初期値設定
            SelectInitIndex();
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


        /// <summary>
        /// ピッカーに初期値を設定する
        /// </summary>
        private void SelectInitIndex()
        {
                    // -1 設定なしの場合、初期値0.0
                    integerPick.SelectedIndex = 0;
                    decimalPick.SelectedIndex = 0;
                    return;
        }


        /// <summary>
        /// ピッカーにアイテムを設定
        /// </summary>
        private void CreateItem()
        {
            // 整数 0~99の100個の配列を作成
            int integer_len = 100;
            string[] integer_item = new string[integer_len];
            for (int i = 0; i < integer_len; i++)
            {
                integer_item[i] = i.ToString();
            }
            integerPick.ItemsSource = integer_item;

            // 少数 0~9までの10個の配列を作成
            int decimal_len = 10;
            string[] decimal_item = new string[decimal_len];
            for (int i = 0; i < decimal_len; i++)
            {
                decimal_item[i] = i.ToString();
            }
            decimalPick.ItemsSource = decimal_item;
        }
    }

}
