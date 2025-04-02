#if IOS || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiTextField;
#elif ANDROID
using PlatformView = AndroidX.AppCompat.Widget.AppCompatEditText;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBox;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using Sample_Maui.Controls;
using Microsoft.Maui.Handlers;

namespace Sample_Maui.Handlers
{
    public partial class CustomEntryHandler
    {
        public static PropertyMapper<CustomEntry, CustomEntryHandler> PropertyMapper = new PropertyMapper<CustomEntry, CustomEntryHandler>(ViewHandler.ViewMapper)
        {
            [nameof(CustomEntry.Text)] = MapText,
            [nameof(CustomEntry.TextColor)] = MapTextColor
        };

        public CustomEntryHandler() : base(PropertyMapper)
        {
        }
    }
}