using Newtonsoft.Json;

namespace NasaWeb.Api.Models
{
    public class EstimatedDiameter
    {
        [JsonProperty(PropertyName = "kilometers")]
        public Kilometers Kilometers { get; set; }
   }
}
