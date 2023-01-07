using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupinisProjektas.Models
{
    public class GenericInputModel
    {
        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("spi")]
        public string Spi { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
    }


}