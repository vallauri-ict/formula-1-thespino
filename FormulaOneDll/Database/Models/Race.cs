using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Race : IModel
    {
        public const string TABLE = "Races";



        private readonly int circuit_id;
        private Circuit circuit = null;

        public Race(int id, string name, int laps, DateTime date, Circuit circuit)
        {
            this.Id = id;
            this.Name = name;
            this.Laps = laps;
            this.Date = date;
            this.Circuit = circuit;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Laps { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Circuit Circuit
        {
            get
            {
                if (circuit == null)
                    circuit = new Tools().API___Circuits_Get(this.circuit_id);

                return circuit;
            }
            set
            {
                circuit = value;
            }
        }



        #region FOR API

        public Race(int id, string name, int laps, DateTime date, int circuit_id)
        {
            this.Id = id;
            this.Name = name;
            this.Laps = laps;
            this.Date = date;
            this.circuit_id = circuit_id;
        }

        public Race(int id, string name, int laps, DateTime date, int circuit_id, long row_num)
        {
            this.Id = id;
            this.Name = name;
            this.Laps = laps;
            this.Date = date;
            this.circuit_id = circuit_id;
        }

        #endregion
    }
}
