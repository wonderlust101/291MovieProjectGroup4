using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    class CustomerOrder
    {
        public string MovieName { get; set; }
        public int? CustomerRating { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
