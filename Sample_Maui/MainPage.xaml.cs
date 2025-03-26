using Sample_Maui.Controls;

namespace Sample_Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

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

        //イベントが発生したときにイベント ハンドラーを実行
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
