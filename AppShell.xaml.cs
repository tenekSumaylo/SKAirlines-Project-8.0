using SKAirlines_Project.Views;

namespace SKAirlines_Project
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute( "MainPage", typeof( MainPage ) );
            Routing.RegisterRoute( "RegisterPage", typeof(RegisterPage) );
            Routing.RegisterRoute("BookingPage", typeof( BookingPage ) );
            Routing.RegisterRoute( "AdminPage", typeof(AdminPage));
        }
    }
}
