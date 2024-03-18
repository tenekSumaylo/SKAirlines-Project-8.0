using Microsoft.Maui;
using SKAirlines_Project.CustomControl;
using Application = Microsoft.Maui.Controls.Application;

namespace SKAirlines_Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage() );

            
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor( Android.Graphics.Color.Transparent );
        
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
#endif
            });
        }
    }
}
