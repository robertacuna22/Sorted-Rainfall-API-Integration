using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Rainfall.Model
{
    public class StationReading
    {
        [JsonProperty("@context")]
        public string context { get; set; }
        public Meta meta { get; set; }
        public IList<Items> items { get; set; }
    }

    public class Meta
    {
        public string publisher { get; set; }
        public string licence { get; set; }
        public string documentation { get; set; }
        public string version { get; set; }
        public string comment { get; set; }
        public IList<string> hasFormat { get; set; }
        public int limit { get; set; }

    }
    public class Items
    {
        [JsonProperty("@id")]
        public string @id { get; set; }
        public DateTime dateTime { get; set; }
        public string measure { get; set; }
        public decimal value { get; set; }

    }


}
