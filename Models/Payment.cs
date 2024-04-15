using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Payment : BaseModel
    {
        private string paymentID = string.Empty;
        private double totalPaymentAmount;
        private DateTime paymentDate;
        private bool isPaid;

        public Payment() { }

        public Payment( string id, double payment, DateTime payDate, bool isPaid)
        {
            PaymentID = id;
            TotalPaymentAmount = payment;
            PaymentDate = payDate;
            IsPaid = isPaid;
        }
        
        public string PaymentID
        {
            get => this.paymentID;
            set
            {
                this.paymentID = value; 
                OnPropertyChanged(nameof(PaymentID));
            }
        }

        public double TotalPaymentAmount
        {
            get => this.totalPaymentAmount;
            set
            {
                this.totalPaymentAmount = value;
                OnPropertyChanged(nameof(TotalPaymentAmount));
            }
        }

        public DateTime PaymentDate
        {
            get => this.paymentDate;
            set
            {
                this.paymentDate = value;
                OnPropertyChanged(nameof(PaymentDate));
            }
        }

        public bool IsPaid
        {
            get => this.isPaid;
            set
            {
                this.isPaid = value;
                OnPropertyChanged(nameof(IsPaid));
            }
        }
    }
}
