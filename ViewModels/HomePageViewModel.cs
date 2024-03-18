using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<ClassPics> imagePics;
        private int selectedFlight;
        private bool pickerState;
        public List<string> TypeOfFlight { get; set; }
        public HomePageViewModel() {
            ImagePics = new ObservableCollection<ClassPics>();
            AddData();
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

        public int SelectedFlight
        {
            get => selectedFlight;
            set
            {
                selectedFlight = value;
                if ( value == 1 )
                {
                    PickerState = false;
                }
                else
                {
                    PickerState = true;
                }
                OnPropertyChanged(nameof(SelectedFlight));
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

    }
}
