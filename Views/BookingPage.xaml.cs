using SKAirlines_Project.Models;
using System.Collections.ObjectModel;

namespace SKAirlines_Project.Views;

public partial class BookingPage : ContentPage
{
    public ObservableCollection<Flight> FlightsAvailable {  get; set; }
    public Flight DummyFlight1;
    public Flight DummyFlight2;
    public BookingPage()
	{
		InitializeComponent();
		BindingContext = this;
        BookFlightPage.IsVisible = false;
        FlightsAvailable = new ObservableCollection<Flight>();
        DummyFlight1 = new Flight("Plane One", DateTime.Now, DateTime.Now, 10, false, false, "Cebu", "Manila", "CebManila000");
        DummyFlight1.Fare = 500;
        DummyFlight2 = new Flight("Plane Two", DateTime.Now, DateTime.Now, 10, false, false, "Tacloban", "Manila", "TacManila0001");
        DummyFlight2.Fare = 1000;
        FlightsAvailable.Add(DummyFlight1);
        FlightsAvailable.Add(DummyFlight2);
        flightsAvail.ItemsSource = FlightsAvailable;
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
}