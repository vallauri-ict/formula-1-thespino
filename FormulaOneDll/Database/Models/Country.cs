using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll.Database.Models
{
    [DataContract(Name = "Country")]
    public class Country
    {
        public Country(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        [DataMember(Name= "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{this.Name} ({this.Code})";
        }
    }
}
