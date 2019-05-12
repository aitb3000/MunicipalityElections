using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MunicipalityElections.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class City
    {
        [JsonProperty(PropertyName = "ccode")]
        public int ccode { get; set; }
        [JsonProperty(PropertyName = "cdistrict")]
        public string cdistrict { get; set; }
        [JsonProperty(PropertyName = "cauthority")]
        public string cauthority { get; set; }
        [JsonProperty(PropertyName = "cpermistionvote")]
        public string cpermistionvote { get; set; }
        [JsonProperty(PropertyName = "ctotalvoted")]
        public string ctotalvoted { get; set; }
        [JsonProperty(PropertyName = "ctotalvoteok")]
        public string ctotalvoteok { get; set; }
        [JsonProperty(PropertyName = "ctotalvotecanceled")]
        public string ctotalvotecanceled { get; set; }
        [JsonProperty(PropertyName = "cspetialvotes")]
        public string cspetialvotes { get; set; }
        [JsonProperty(PropertyName = "cvotepercentage")]
        public string cvotepercentage { get; set; }

        public virtual ICollection<Candidate> CityCandidates { get; set; }
    }
}

//    EXAMPLE
//-----------------------------
//"קוד רשות": "0472",
//"מחוז": "ירושלים",
//"רשות": "אבו גוש",
//"בז\"ב": "5403",
//"מספר מצביעים": "4675",
//"מספר קולות כשרים": "4536",
//"מספר קולות פסולים": "139",
//"קולות מיוחדים? כן/לא": "כן",
//"אחוז הצבעה": "86.5"