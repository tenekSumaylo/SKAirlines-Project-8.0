using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Passenger : BaseModel
    {
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private DateTime birthDate;
        private int ageStage;
        private string title;
        public Passenger()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            EmailAddress = string.Empty;
            PhoneNumber = string.Empty;
            BirthDate = DateTime.Now;
            AgeStage = 0;
            Title = string.Empty;
             
        }

        public Passenger( int ageS, int sequence)
        {
            if (ageS == 1)
            {
                Title = "Adult" + "-" + sequence;
            }
            else if (ageS == 2)
            {
                Title = "Child" + "-" + sequence;
            }
            else
            {
                Title = "Infant" + "-" + sequence;
            }

        }

        public Passenger(string firstN, string lastN, string email, DateTime birth, int ageS)
        {
            FirstName = firstN;
            LastName = lastN;
            EmailAddress = email;
            BirthDate = birth;
            AgeStage = ageS;
            if ( ageS == 1 )
            {
                Title = "Adult";
            }
            else if ( ageS == 2 )
            {
                Title = "Child";
            }
            else
            {
                Title = "Infant";
            }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Title
        {
            get => this.title;
            set
            {
                this.title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string EmailAddress
        {
            get => this.emailAddress;
            set
            {
                this.emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
            }
        }
        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                this.phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public DateTime BirthDate
        {
            get => this.birthDate;
            set
            {
                this.birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public int AgeStage
        {
            get => this.ageStage;
            set
            {
                this.ageStage = value;
                OnPropertyChanged(nameof(AgeStage));
            }
        }

        protected void ClearForm()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            EmailAddress = String.Empty;
            PhoneNumber = String.Empty;
            BirthDate = DateTime.Now;
            AgeStage = -1;
        }
    }
}
