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
            MainPage = new AppShell();
        }
    }
}
