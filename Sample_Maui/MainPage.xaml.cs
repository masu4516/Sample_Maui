using RGPopup.Maui.Extensions;
using Sample_Maui.Controls;

namespace Sample_Maui
{
    public partial class MainPage : ContentPage
    {
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
            
           popup_page = new PopupPicker();
            Navigation.PushAsync(popup_page, true);
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
