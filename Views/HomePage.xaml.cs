using System.Collections.ObjectModel;
using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using SKAirlines_Project.ViewModels;
namespace SKAirlines_Project.Views;

public partial class HomePage : ContentPage
{
    AdminService checkFlights = new AdminService("Flights.json");
    public string theOrigin { get; set; }
    public string theDestination { get; set; }
    public DateTime OneWay { get; set;  }
	public HomePage( HomePageViewModel vm )
	{
		InitializeComponent();
		BindingContext = vm;
        FromPlace.ItemsSource = originPlaces;
        ToPlace.ItemsSource = originPlaces;
        FromPlace.SelectedIndex = 1;
        ToPlace.SelectedIndex = 1;
        OneWayTo.Date = DateTime.Now;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string findDest, theOrig;
        ObservableCollection<Flight> availableFlights = await checkFlights.GetFlights();
        int j = 0;
        if ( FromPlace.SelectedIndex == 0 || ToPlace.SelectedIndex == 0 )
        {
            return;
        }

        findDest = GetPlace( ToPlace.SelectedIndex );
        theOrig = GetPlace(FromPlace.SelectedIndex);
        foreach ( var f in availableFlights )
        {
            if ( f.OriginPlace == theOrig && f.DestinationPlace == findDest && f.FlightDate.Month ==  OneWayTo.Date.Month && f.FlightDate.Year == OneWayTo.Date.Year && f.FlightDate.Day == OneWayTo.Date.Day)
            {
                await Navigation.PushAsync(new BookingPage(f.DestinationPlace, f.OriginPlace, f.FlightDate ));
                j++;
            }
        }
        if ( j == 0 )
        {
            await DisplayAlert("Flight Not Found", "No Flights Avaialble", "Confirm");
        }

    }

    private string GetPlace( int indexed )
    {
        int i = 0;

        foreach ( string s in originPlaces )
        {
            if ( i == indexed )
            {
                return s;
            }
            ++i;
        }
        return "";
    }


    List<string> originPlaces = new List<string>()
    {
        "SELECT","Bacolod", "Bohol", "Boracay (Caticlan)", "Butuan", "Cagayan de Oro", "Calbayog", "Camiguin", "Cebu", "Clark",
        "Coron (Busuanga)", "Cotabato", "Davao", "Dipolog", "Dumaguete", "Iloilo", "Kalibo", "Laoag", "Legazpi (Daraga)",
        "Manila", "Masbate", "Naga", "Ozamiz", "Pagadian", "Puerto Princesa", "Roxas", "San Jose (Mindoro)", "Siargao",
        "Surigao", "Tacloban", "Tawi-Tawi", "Tuguegarao", "Virac", "Zamboanga"
    };

}