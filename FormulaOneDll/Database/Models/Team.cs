using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    public class Team
    {
        public Team(int id, string name, string fullTeamName, Country country, string powerUnit, string technicalChief, string chassis, Driver firstDriver, Driver secondDriver)
        {
            this.Id = id;
            this.Name = name;
            this.FullTeamName = fullTeamName;
            this.Country = country;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.FirstDriver = firstDriver;
            this.SecondDriver = secondDriver;
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public string FullTeamName { get; set; }

        public Country Country { get; set; }

        public string PowerUnit { get; set; }

        public string TechnicalChief { get; set; }

        public string Chassis { get; set; }

        public Driver FirstDriver { get; set; }

        public Driver SecondDriver { get; set; }


        public override string ToString()
        {
            return $"{this.Name} ({this.Country.Code})";
        }
    }
}
