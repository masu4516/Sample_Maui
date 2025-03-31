using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Sample_Maui.Controls;
using static Android.Provider.MediaStore;

namespace Sample_Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler(typeof(MyPicker), typeof(Platforms.Android.Handlers.MyPickerHandler));
                    //handlers.AddHandler(typeof(Label), typeof(Platforms.Android.Handlers.CustomLabelHandler));
#endif
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
