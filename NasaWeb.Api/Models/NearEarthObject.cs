using Newtonsoft.Json;

using System.Collections.Generic;

namespace NasaWeb.Api.Models
{
    public class NearEarthObject
    {

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty(PropertyName = "is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty(PropertyName = "close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }
    }
}
