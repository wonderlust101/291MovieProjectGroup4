using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    public class Movie
    {
        public string title { get; set; }
        public string genre { get; set; }
        public decimal fee { get; set; }
        public int totalCopies { get; set; }
    }
}
