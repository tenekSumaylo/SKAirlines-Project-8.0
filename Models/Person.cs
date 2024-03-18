using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Person : BaseModel
    {
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private DateTime birthDate;
        private int ageStage;
        public Person()
        {
        }

        public Person(string firstN, string lastN, string email, DateTime birth, int ageS)
        {
            FirstName = firstN;
            LastName = lastN;
            EmailAddress = email;
            BirthDate = birth;
            AgeStage = ageS;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public int AgeStage
        {
            get => ageStage;
            set
            {
                ageStage = value;
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
