using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Result : IModel
    {
        public const string TABLE = "Results";



        private readonly int driver_id;
        private readonly int race_id;

        private Driver driver = null;
        private Race race = null;


        public Result(int id, int position, int score, string fastestLap, Driver driver, Race race)
        {
            this.Id = id;
            this.Position = position;
            this.Score = score;
            this.FastestLap = fastestLap;
            this.Driver = driver;
            this.Race = race;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Position { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public string FastestLap { get; set; }

        [DataMember]
        public Driver Driver
        {
            get
            {
                if (driver == null)
                    driver = new Tools().API___Drivers_Get(this.driver_id);

                return driver;
            }
            set
            {
                driver = value;
            }
        }

        [DataMember]
        public Race Race
        {
            get
            {
                if (race == null)
                    race = new Tools().API___Races_Get(this.race_id);

                return race;
            }
            set
            {
                race = value;
            }
        }



        #region FOR API

        public Result(int id, int position, int score, string fastestLap, int driver_id, int race_id)
        {
            this.Id = id;
            this.Position = position;
            this.Score = score;
            this.FastestLap = fastestLap;
            this.driver_id = driver_id;
            this.race_id = race_id;
        }

        public Result(int id, int position, int score, string fastestLap, int driver_id, int race_id, long row_num)
        {
            this.Id = id;
            this.Position = position;
            this.Score = score;
            this.FastestLap = fastestLap;
            this.driver_id = driver_id;
            this.race_id = race_id;
        }

        #endregion
    }
}
