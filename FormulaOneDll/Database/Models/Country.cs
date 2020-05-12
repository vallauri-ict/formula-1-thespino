using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract]
    public class Country : IModel
    {
        public const string TABLE = "Countries";


        public Country(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }


        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{this.Name} ({this.Code})";
        }



        #region FOR API

        public Country(string code, string name, long row_num)
        {
            this.Code = code;
            this.Name = name;
        }

        #endregion
    }
}
