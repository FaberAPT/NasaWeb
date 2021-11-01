using Newtonsoft.Json;

namespace NasaWeb.Api.Models
{
    public class CloseApproachData
    {
        [JsonProperty(PropertyName = "close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonProperty(PropertyName = "relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonProperty(PropertyName = "orbiting_body")]
        public string OrbitingBody { get; set; }
    }
}
