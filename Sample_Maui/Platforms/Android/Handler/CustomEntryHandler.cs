#nullable enable
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Sample_Maui.Controls;

namespace Sample_Maui.Handlers
{
    public partial class CustomEntryHandler : ViewHandler<CustomEntry, AppCompatEditText>
    {
        protected override AppCompatEditText CreatePlatformView() => new AppCompatEditText(Context);
        
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any control setup here
        }

        protected override void DisconnectHandler(AppCompatEditText platformView)
        {
            // Perform any native view cleanup here
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public static void MapText(CustomEntryHandler handler, CustomEntry view)
        {
            handler.PlatformView.Text = view.Text;
            handler.PlatformView?.SetSelection(handler.PlatformView?.Text?.Length ?? 0);
        }

        public static void MapTextColor(CustomEntryHandler handler, CustomEntry view)
        {
            handler.PlatformView?.SetTextColor(view.TextColor.ToPlatform());
        }
    }
}