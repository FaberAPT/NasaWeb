using Newtonsoft.Json;

namespace NasaWeb.Api.Models
{
    public class RelativeVelocity
    {
        [JsonProperty(PropertyName = "kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonProperty(PropertyName = "kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonProperty(PropertyName = "miles_per_hour")]
        public string MilesPerHour { get; set; }
    }
}
