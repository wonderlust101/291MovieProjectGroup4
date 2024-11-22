using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Fee { get; set; }
        public int TotalCopies { get; set; }
    }
}
