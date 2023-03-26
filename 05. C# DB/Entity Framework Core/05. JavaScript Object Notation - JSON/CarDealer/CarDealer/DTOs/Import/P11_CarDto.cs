using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class P11_CarDto
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }
    }
}
