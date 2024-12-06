using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieRental
{
    public class Actor
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }

        public DateTime dateOfBirth { get; set; }

        // Computed property
        public string fullName => $"{firstName} {lastName}";

        public override string ToString()
        {
            return fullName;
        }
    }
}
