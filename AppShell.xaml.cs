using SKAirlines_Project.Views;

namespace SKAirlines_Project
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute( "MainPage", typeof( MainPage ) );
            Routing.RegisterRoute( "MainPage/RegisterPage", typeof(RegisterPage) );
            Routing.RegisterRoute( "MainPage/HomePage", typeof(HomePage));
            Routing.RegisterRoute( "HomePage/BookingPage", typeof( BookingPage ) );
            Routing.RegisterRoute( "AdminPage", typeof(AdminPage));
        }
    }
}
