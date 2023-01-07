using Newtonsoft.Json;

namespace GrupinisProjektas.Models
{
    public class Reverse
    {
        [JsonProperty("frequency")]
        public int frequency { get; set; }

        [JsonProperty("data")]
        public Object data { get; set; }
    }
}
