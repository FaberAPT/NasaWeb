using Newtonsoft.Json;

using System.Collections.Generic;

namespace NasaWeb.Api.Models
{
    public class Root
    {
        [JsonProperty(PropertyName = "near_earth_objects")]
        public List<NearEarthObject> NearEarthObjects { get; set; }
    }
}
