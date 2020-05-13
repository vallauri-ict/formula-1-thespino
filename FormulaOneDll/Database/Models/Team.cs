using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Team : IModel
    {
        public const string TABLE = "Teams";


        private readonly string country_code;
        private readonly int driver1_id;
        private readonly int driver2_id;
        private Country country = null;
        private Driver driver1 = null;
        private Driver driver2 = null;


        public Team(int id, string name, string fullTeamName, string powerUnit, string technicalChief, string chassis, string imageurl, Country country, Driver driver1, Driver driver2)
        {
            this.Id = id;
            this.Name = name;
            this.FullName = fullTeamName;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.ImageUrl = imageurl;

            this.Country = country;
            this.Driver1 = driver1;
            this.Driver2 = driver2;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string PowerUnit { get; set; }

        [DataMember]
        public string TechnicalChief { get; set; }

        [DataMember]
        public string Chassis { get; set; }

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

        [DataMember]
        public Driver Driver1
        {
            get
            {
                if (driver1 == null)
                    driver1 = new Tools().API___Drivers_Get(this.driver1_id);

                return driver1;
            }
            set
            {
                driver1 = value;
            }
        }

        [DataMember]
        public Driver Driver2
        {
            get
            {
                if (driver2 == null)
                    driver2 = new Tools().API___Drivers_Get(this.driver2_id);

                return driver2;
            }
            set
            {
                driver2 = value;
            }
        }


        public override string ToString()
        {
            return $"{this.Name} ({this.Country.Code})";
        }



        #region FOR API

        public Team(int id, string name, string fullName, string powerUnit, string technicalChief, string chassis, string imageurl, string country_code, int driver1_id, int driver2_id)
        {
            var db = new Tools();

            this.Id = id;
            this.Name = name;
            this.FullName = fullName;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.ImageUrl = imageurl;


            this.country_code = country_code;
            this.driver1_id = driver1_id;
            this.driver2_id = driver2_id;
        }

        public Team(int id, string name, string fullName, string powerUnit, string technicalChief, string chassis, string imageurl, string country_code, int driver1_id, int driver2_id, long row_num)
        {
            this.Id = id;
            this.Name = name;
            this.FullName = fullName;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.ImageUrl = imageurl;

            this.country_code = country_code;
            this.driver1_id = driver1_id;
            this.driver2_id = driver2_id;
        }

        #endregion
    }
}
