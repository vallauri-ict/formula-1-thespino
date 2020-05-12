using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Circuit : IModel
    {
        public const string TABLE = "Circuits";



        private readonly string country_code;
        private Country country = null;


        public Circuit(int id, string name, string length, string recordLap, string location, string imageUrl, Country country)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.RecordLap = recordLap;
            this.Location = location;
            this.ImageUrl = imageUrl;
            this.Country = country;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Length { get; set; }

        [DataMember]
        public string RecordLap { get; set; }

        [DataMember]
        public string Location { get; set; }

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
            return $"{this.Name} ({this.Location} - {this.Country.Name})";
        }



        #region FOR API

        public Circuit(int id, string name, string length, string recordLap, string location, string imageUrl, string country_code)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.RecordLap = recordLap;
            this.Location = location;
            this.ImageUrl = imageUrl;
            this.country_code = country_code;
        }

        public Circuit(int id, string name, string length, string recordLap, string location, string imageUrl, string country_code, long row_num)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.RecordLap = recordLap;
            this.Location = location;
            this.ImageUrl = imageUrl;
            this.country_code = country_code;
        }

        #endregion
    }
}
