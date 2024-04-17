using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using System.Collections.ObjectModel;

namespace SKAirlines_Project.Views;

public partial class AdminPage : ContentPage
{
    public Flight theFlight { get; set; }
	public string Orig { get; set; }
	public string Dest { get; set; }
	public string testSeat { get; set; }
	public int seats { get; set; }
	AdminService adservice;
    public AdminPage()
	{
		InitializeComponent();
		BindingContext = this;
		origin.ItemsSource = originPlaces;
		destination.ItemsSource = originPlaces;
		adservice = new AdminService("Flights.json");
		theFlight = new Flight();
	}

	List<string> originPlaces = new List<string>()
	{
		"Bacolod", "Bohol", "Boracay (Caticlan)", "Butuan", "Cagayan de Oro", "Calbayog", "Camiguin", "Cebu", "Clark",
		"Coron (Busuanga)", "Cotabato", "Davao", "Dipolog", "Dumaguete", "Iloilo", "Kalibo", "Laoag", "Legazpi (Daraga)",
		"Manila", "Masbate", "Naga", "Ozamiz", "Pagadian", "Puerto Princesa", "Roxas", "San Jose (Mindoro)", "Siargao",
		"Surigao", "Tacloban", "Tawi-Tawi", "Tuguegarao", "Virac", "Zamboanga"
	};

    private async void Button_Clicked(object sender, EventArgs e)
    {
		theFlight.OriginPlace = GetPlace( origin.SelectedIndex);
		theFlight.DestinationPlace = GetPlace( destination.SelectedIndex);
		seats = Convert.ToInt32(testSeat);
		theFlight.NumberOfSeats = seats;
		//MakeSeats();
		ObservableCollection<Flight> theFlights = await adservice.GetFlights();
		theFlights.Add(theFlight);
		adservice.SaveToFile(theFlights);
		await Navigation.PopAsync();
    }

	private void MakeSeats()
	{
		for ( int i = 1; i <= seats; i++ )
		{
			Seat checkSeat = new Seat("ljweh1", i, false);
			theFlight.TheSeats.Add(checkSeat);
		}
	}

    private string GetPlace(int indexed)
    {
        int i = 0;

        foreach (string s in originPlaces)
        {
            if (i == indexed)
            {
                return s;
            }
            ++i;
        }
        return "";
    }
}