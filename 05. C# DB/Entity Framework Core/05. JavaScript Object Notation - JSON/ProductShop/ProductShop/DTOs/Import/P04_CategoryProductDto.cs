using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class P04_CategoryProductDto
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
