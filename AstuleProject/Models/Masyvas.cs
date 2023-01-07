using Newtonsoft.Json;

namespace GrupinisProjektas.Models
{
    public class Masyvas
    {
        [JsonProperty("array")]
        public Object data { get; set; }
    }
}
