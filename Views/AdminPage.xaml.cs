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
	public int Seats { get; set; }
	public DateTime flightTime;
	AdminService adservice;
    public AdminPage()
	{
		InitializeComponent();
		BindingContext = this;
		origin.ItemsSource = originPlaces;
		destination.ItemsSource = originPlaces;
		adservice = new AdminService("Flights.json");
		theFlight = new Flight();
		flightTime = DateTime.Now;
		dateFlight.Date = DateTime.Now;
		planetype.ItemsSource = planes;
		TimeofFlight.Time = TimeSpan.MinValue;
        FlightName.Text = "Flight" + "-" + Convert.ToString(adservice.GetNumberOfFLights().Result + 1);
		dateFlight.MinimumDate = DateTime.Now;
        //FlightName.Text = "Flight" + "-" + Convert.ToString(Convert.ToInt32(adservice.GetNumberOfFLights()) + 1); 
    }

	List<string> originPlaces = new List<string>()
	{
		"Bacolod", "Bohol", "Boracay (Caticlan)", "Butuan", "Cagayan de Oro", "Calbayog", "Camiguin", "Cebu", "Clark",
		"Coron (Busuanga)", "Cotabato", "Davao", "Dipolog", "Dumaguete", "Iloilo", "Kalibo", "Laoag", "Legazpi (Daraga)",
		"Manila", "Masbate", "Naga", "Ozamiz", "Pagadian", "Puerto Princesa", "Roxas", "San Jose (Mindoro)", "Siargao",
		"Surigao", "Tacloban", "Tawi-Tawi", "Tuguegarao", "Virac", "Zamboanga"
	};

    List<string> planes = new List<string>() { 
		"F-16","Airbus A220", "Boeing 767", "Comac-C919"
    };

    private async void Button_Clicked(object sender, EventArgs e)
    {
		theFlight.FlightID = "Flight" + "-" + Convert.ToString( adservice.GetNumberOfFLights().Result + 1 );
		theFlight.PlaneName = GetPlane(planetype.SelectedIndex);  // planeName
		theFlight.OriginPlace = GetPlace( origin.SelectedIndex);  // origin
		theFlight.DestinationPlace = GetPlace( destination.SelectedIndex);  // destination
		theFlight.Fare = Convert.ToDouble(fare.Text);  // fare
		Seats = Convert.ToInt32(numSeat.Text); // seats
		theFlight.NumberOfSeats = Seats;  // seats
		theFlight.FlightDate = dateFlight.Date;  // date 
		theFlight.FlightTime = TimeofFlight.Time;
		MakeSeats(); 
		ObservableCollection<Flight> theFlights = await adservice.GetFlights();
		theFlights.Add(theFlight);
		adservice.SaveToFile(theFlights);
		await Shell.Current.GoToAsync("//MainPage");
    }

	private void MakeSeats()
	{
		Seat checkSeat;
		for ( int i = 1; i <= Seats; i++ )
		{
			checkSeat = new Seat(Convert.ToString(theFlight.PlaneName[0]), i, false, 0);
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

    private string GetPlane(int indexed)
    {
        int i = 0;

        foreach (string s in planes	)
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