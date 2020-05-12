using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Driver : IModel
    {
        public const string TABLE = "Drivers";


        private string country_code;
        private Country country;


        public Driver(int id, string firstname, string lastname, DateTime dob, string pob, string imageurl, Country country)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Pob = pob;
            this.ImageUrl = imageurl;
            this.Country = country;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime Dob { get; set; }

        [DataMember]
        public string Pob { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public Country Country
        {
            get
            {
                if (country == null)
                    country = new Tools().API___Countries_Get(this.country_code);

                return country;
            }
            set
            {
                country = value;
            }
        }


        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }




        #region FOR API

        public Driver(int id, string firstname, string lastname, DateTime dob, string pob, string imageurl, string country_code)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Pob = pob;
            this.ImageUrl = imageurl;
            this.country_code = country_code;
        }

        public Driver(int id, string firstname, string lastname, DateTime dob, string pob, string imageurl, string country_code, long row_num)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Pob = pob;
            this.ImageUrl = imageurl;
            this.country_code = country_code;
        }

        #endregion
    }
}
