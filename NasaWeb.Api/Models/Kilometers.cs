using Newtonsoft.Json;

namespace NasaWeb.Api.Models
{
    public class Kilometers
    {
        [JsonProperty(PropertyName = "estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty(PropertyName = "estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
