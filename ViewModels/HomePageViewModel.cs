using SKAirlines_Project.Models;
using SKAirlines_Project.ServiceModel;
using SKAirlines_Project.Services;
using SKAirlines_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKAirlines_Project.ViewModels
{
    [QueryProperty(nameof(TheUser), "TheUser")]
    public class HomePageViewModel : BaseViewModel
    {
        AdminService checkFlights = new AdminService("Flights.json");
        private UserDomain theUser; 
        private ObservableCollection<ClassPics> imagePics;
        private int flightType;
        private int selectedFlightOne;
        private int selectedFlightTwo;
        private bool pickerState;
        private DateTime oneWay;
        private DateTime twoWay;
        private bool isRoundTrip;
        private string otin;
        public List<string> Places { get; set; }

        public DataPasser TheDataPassed { get; set; }
        public ICommand SearchCommand => new Command(SearchFlight);

        public List<string> TypeOfFlight { get; set; }
        public HomePageViewModel() {
            ImagePics = new ObservableCollection<ClassPics>();
            AddData();
            Places = ReturnPlaces();
            OneWay = DateTime.Now;
            TwoWay = DateTime.Now;

        }

        public string Otin
        {
            get => this.otin;
            set
            {
                this.otin = value;
                OnPropertyChanged(nameof(Otin));
            }
        }

        public UserDomain TheUser
        {
            get => this.theUser;
            set
            {
                this.theUser = value;
                Otin = nameof(TheUser.UserID);
                OnPropertyChanged(nameof(TheUser));
            }
        }

        public bool IsRoundTrip
        {
            get => this.isRoundTrip;
            set
            {
                this.isRoundTrip = value;
                OnPropertyChanged(nameof(IsRoundTrip));
            }
        }

        public bool PickerState
        {
            get => pickerState;
            set
            {
                pickerState = value;
                OnPropertyChanged(nameof(PickerState));
            }
        }

        public int SelectedFlightOne
        {
            get => this.selectedFlightOne;
            set
            {
                this.selectedFlightOne = value;
                OnPropertyChanged(nameof(SelectedFlightOne));
            }
        }

        public int SelectedFlightTwo
        {
            get => this.selectedFlightTwo;
            set
            {
                this.selectedFlightTwo = value;
                OnPropertyChanged(nameof(SelectedFlightTwo));
            }
        }

        public int FlightType
        {
            get => this.flightType;
            set
            {
                this.flightType = value;
                if ( value == 1 )
                {
                    PickerState = false;
                    IsRoundTrip = false;
                }
                else
                {
                    PickerState = true;
                    IsRoundTrip = true;
                }
                OnPropertyChanged(nameof(FlightType));
            }
        }

        public ObservableCollection<ClassPics> ImagePics
        {
            get => imagePics;
            set
            {
                imagePics = value;
                OnPropertyChanged(nameof(ImagePics));
            }
        }

        public DateTime OneWay
        {
            get => this.oneWay;
            set
            {
                this.oneWay = value;
                OnPropertyChanged(nameof(OneWay));
            }
        }

        public DateTime TwoWay
        {
            get => this.twoWay;
            set
            {
                this.twoWay = value;
                OnPropertyChanged(nameof(TwoWay));
            }
        }



        public void AddData()
        {
            ClassPics nameOne = new ClassPics("firstpic.png");
            ClassPics nameTwo = new ClassPics("secondpic.png");
            ClassPics nameThird = new ClassPics("thirdpic.png");
            ClassPics nameFourth = new ClassPics("fourthpic.png");
            ImagePics.Add(nameOne);
            ImagePics.Add(nameTwo);
            ImagePics.Add(nameThird);
            ImagePics.Add(nameFourth);
            TypeOfFlight = new List<string>()
            {
                "Flight Type","One Way","Two Way"
            };
        }


        private async void SearchFlight()
        {
            string findDest, theOrig;
            ObservableCollection<Flight> availableFlights = await checkFlights.GetFlights();
            int j = 0;

            if ( FlightType == 0 )
            {
                await Shell.Current.DisplayAlert("Choose Flight Type", "Cannot Proceed", "Close");
                return;
            }
            findDest = GetPlace(SelectedFlightTwo);
            theOrig = GetPlace(SelectedFlightOne);
            foreach (var f in availableFlights)
            {
                if (f.OriginPlace == theOrig && f.DestinationPlace == findDest && f.FlightDate.Month == OneWay.Month && f.FlightDate.Year == OneWay.Year && f.FlightDate.Day == OneWay.Day && IsRoundTrip == false)
                {
                    TheDataPassed = new DataPasser(TheUser,f.OriginPlace, f.DestinationPlace, f.FlightDate, DateTime.Now, IsRoundTrip);
                    var theDictionary = new Dictionary<string, object>
                    {
                        {"TheDataPassed", TheDataPassed }
                    };
                    await Shell.Current.GoToAsync(nameof(BookingPage));
                  //  await Shell.Current.GoToAsync($"{nameof(BookingPage)}", theDictionary);
                    j++;
                }
                else if  ( IsRoundTrip == true ) 
                {
                    if (f.OriginPlace == theOrig && f.DestinationPlace == findDest && f.FlightDate.Month == OneWay.Month && f.FlightDate.Year == OneWay.Year && f.FlightDate.Day == OneWay.Day )
                    {

                    }

                    if (f.OriginPlace == theOrig && f.DestinationPlace == findDest && f.FlightDate.Month == OneWay.Month && f.FlightDate.Year == OneWay.Year && f.FlightDate.Day == OneWay.Day)
                    {

                    }
                }
            }
            if (j == 0)
            {
                await Shell.Current.DisplayAlert("Flight Not Found", "No Flights Avaialble", "Confirm");
            }

        }

        private string GetPlace(int indexed)
        {
            int i = 0;

            foreach (string s in Places)
            {
                if (i == indexed)
                {
                    return s;
                }
                ++i;
            }
            return "";
        }

        public List<string> ReturnPlaces() => new List<string>()
        {
        "Bacolod", "Bohol", "Boracay (Caticlan)", "Butuan", "Cagayan de Oro", "Calbayog", "Camiguin", "Cebu", "Clark",
        "Coron (Busuanga)", "Cotabato", "Davao", "Dipolog", "Dumaguete", "Iloilo", "Kalibo", "Laoag", "Legazpi (Daraga)",
        "Manila", "Masbate", "Naga", "Ozamiz", "Pagadian", "Puerto Princesa", "Roxas", "San Jose (Mindoro)", "Siargao",
        "Surigao", "Tacloban", "Tawi-Tawi", "Tuguegarao", "Virac", "Zamboanga" };
    }
}
