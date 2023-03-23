using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P06_UserDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("soldProducts")]
        public ICollection<P06_ProductDto> ProductsSold { get; set; } = null!;
    }
}
