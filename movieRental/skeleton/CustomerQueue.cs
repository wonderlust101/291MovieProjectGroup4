using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    public class CustomerQueue
    {
        public string MovieName { get; init; }
        public string MovieGenre { get; init; }
        public int TotalCopies { get; init; }
        public int CopiesAvailable { get; init; }
        public DateTime DateAdded { get; init; }
        public int MovieID { get; set; }

    }
}
