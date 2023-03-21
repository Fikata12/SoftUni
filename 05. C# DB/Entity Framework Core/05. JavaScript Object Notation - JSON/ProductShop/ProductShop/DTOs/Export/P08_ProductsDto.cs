using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P08_ProductsDto
    {
        [JsonProperty("count")]
        public int ProductsCount { get; set; }

        [JsonProperty("products")]
        public ICollection<P08_ProductDto> Products { get; set; } = null!;
    }
}