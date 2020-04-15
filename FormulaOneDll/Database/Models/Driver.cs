using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    public class Driver
    {
        public Driver(int id, string firstname, string lastname, DateTime dob, string placeOfBirth, Country country)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Dob = dob;
            this.PlaceOfBirth = placeOfBirth;
            this.Country = country;
        }


        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Dob { get; set; }

        public string PlaceOfBirth { get; set; }

        public Country Country { get; set; }


        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname}";
        }
    }
}
