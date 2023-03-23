using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P06_ProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string? buyerFirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string buyerLastName { get; set; } = null!;
    }
}
