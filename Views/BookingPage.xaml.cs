using SKAirlines_Project.Models;
using System.Collections.ObjectModel;

namespace SKAirlines_Project.Views;

public partial class BookingPage : ContentPage
{
    public ObservableCollection<Flight> FlightsAvailable {  get; set; }
    public Flight DummyFlight1;
    public Flight DummyFlight2;
    public Person person1;
    public Person person2;
    public ObservableCollection<Person> GuestsInput {  get; set; }
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
        GuestsInput = new ObservableCollection<Person>();
        person1 = new Person("Kevin", "Durant", "hehe@gmail.com", DateTime.Now, 1);
        person2 = new Person("John", "Durant", "hehe@gmail.com", DateTime.Now, 3);
        GuestsInput.Add(person1);
        GuestsInput.Add(person2);
        inputG.IsVisible = false;
        Guests.ItemsSource = GuestsInput;
        AddOns.IsVisible = false;
        seatSelection.IsVisible = false;
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
}