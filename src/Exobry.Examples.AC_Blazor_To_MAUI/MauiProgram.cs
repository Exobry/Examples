using Exobry.Examples.AA_BlazorState_MediatR.Pages;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace Exobry.Examples.AC_Blazor_To_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddBlazorWebView();
            builder.Services.ConfigurePagesServices(typeof(MauiProgram));

            return builder.Build();
        }
    }
}