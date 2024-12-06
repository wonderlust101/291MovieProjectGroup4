using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string postalCode { get; set; }
        public string email { get; set; }
        public int accountNumber { get; set; }
        public string creditCard { get; set; }

        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string phoneNumber3 { get; set; }


        public DateTime CreationDate { get; set; }

        // Computed property
        public string fullName => $"{firstName} {lastName}";
    }
}
