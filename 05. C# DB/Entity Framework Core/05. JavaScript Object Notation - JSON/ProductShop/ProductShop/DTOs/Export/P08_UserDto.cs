using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P08_UserDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public virtual P08_ProductsDto ProductsSold { get; set; } = null!;
    }
}