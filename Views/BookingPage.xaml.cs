using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using System.Collections.ObjectModel;

namespace SKAirlines_Project.Views;

public partial class BookingPage : ContentPage
{
    public ObservableCollection<Flight> FlightsAvailable {  get; set; }
    public Flight DummyFlight1;
    public Flight DummyFlight2;
    public Passenger person1;
    public Passenger person2;
    public ObservableCollection<Passenger> GuestsInput {  get; set; }
    private AdminService adService = new AdminService("Flights.json");
    public int NumPassengers {  get; set; }
    public BookingPage( string destination, string origin, DateTime flightDate )
	{
		InitializeComponent();
		BindingContext = this;
        BookFlightPage.IsVisible = false;
        FlightsAvailable = new ObservableCollection<Flight>();
        FindFlight( destination, origin, flightDate );
        flightsAvail.ItemsSource = FlightsAvailable;
        GuestsInput = new ObservableCollection<Passenger>();

        person1 = new Passenger("Kevin", "Durant", "hehe@gmail.com", DateTime.Now, 1);
     //   person2 = new Passenger("John", "Durant", "hehe@gmail.com", DateTime.Now, 3);
    //    GuestsInput.Add(person1);
        //GuestsInput.Add(person2);
        inputG.IsVisible = false;
        Guests.ItemsSource = GuestsInput;
        AddOns.IsVisible = false;
        seatSelection.IsVisible = false;
        NumPassengers = 0;
    }

    public async void FindFlight( string destination, string origin, DateTime flightDate)
    {
        ObservableCollection<Flight> GetAllFlights = await adService.GetFlights();
        foreach ( var b in GetAllFlights )
        {
            if ( b.OriginPlace == origin && b.DestinationPlace == destination && b.FlightDate.Month == flightDate.Date.Month && b.FlightDate.Year == flightDate.Date.Year && b.FlightDate.Day == flightDate.Date.Day)
            {
                FlightsAvailable.Add(b);
            }
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        GuestAppend.IsVisible = false;
        BookFlightPage.IsVisible = true;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Moves(object sender, EventArgs e)
    {
        GuestAppend.IsVisible = false;
        BookFlightPage.IsVisible = true;
    }

    /*    private void ChangeColor( int n )
        {
            Color[] MenuColors = new Color[5];

            for ( int i = 0; i < MenuColors.Length; ++i )
            {
                if ( i == n )
                {
                    MenuColors[i] = Color.FromArgb("1E90F");
                }
                else
                {
                    MenuColors[i] = Color.FromArgb("19B0EC");
                }
            }
            label1.BackgroundColor = MenuColors[0];
            label2.BackgroundColor = MenuColors[1];
            label3.BackgroundColor = MenuColors[2];
            label4.BackgroundColor = MenuColors[3];
            label5.BackgroundColor = MenuColors[4];
        } */

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        GuestAppend.IsVisible = true;
        BookFlightPage.IsVisible = false;
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        GuestAppend.IsVisible = false;
        BookFlightPage.IsVisible= true;
    }

    private void FlightsAvail_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BookFlightPage.IsVisible = false;
        GuestAppend.IsVisible = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        BookFlightPage.IsVisible = false;
        inputG.IsVisible = true;
        NumPassengers = Convert.ToInt32(stepperK.Value + stepperA.Value + stepperS.Value);
        GuestsInput.Clear();
        CreateGuests();
        Guests.ItemsSource = GuestsInput;

    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        inputG.IsVisible = false;
        BookFlightPage.IsVisible = true;
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        inputG.IsVisible = false;
        AddOns.IsVisible = true;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        AddOns.IsVisible = false;
        seatSelection.IsVisible = true;
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Button_Clicked_7(object sender, EventArgs e)
    {
        AddOns.IsVisible = true;
        seatSelection.IsVisible = false;
    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    public void CreateGuests()
    {
        Passenger ChainPerson;
        for (int i = 1; i <= NumPassengers; ++i)
        {
            if (i <= stepperK.Value)
            {
                ChainPerson = new Passenger(1);
            }
            else if (i <= stepperK.Value + stepperA.Value)
            {
                ChainPerson = new Passenger(2);
            }
            else
            {
                ChainPerson = new Passenger(3);
            }
            ChainPerson.Title += "-" + i;
            GuestsInput.Add( ChainPerson );
        }
    }
}