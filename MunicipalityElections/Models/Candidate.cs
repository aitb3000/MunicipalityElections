using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalityElections.Models
{
    public class Candidate
    {
        [JsonProperty(PropertyName = "cdistrict")]
        public string cdistrict { get; set; }

        [JsonProperty(PropertyName = "cauthority")]
        public string cauthority { get; set; }

        [JsonProperty(PropertyName = "cname")]
        public string cname { get; set; }

        [JsonProperty(PropertyName = "cvoted")]
        public string cvoted { get; set; }

        [JsonProperty(PropertyName = "cpercentage")]
        public string cpercentage { get; set; }

        [JsonProperty(PropertyName = "cwin")]
        public string cwin { get; set; }
    }
}