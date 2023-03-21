using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.DTOs.Export
{
    public class P07_CategoryDto
    {
        [JsonProperty("category")]
        public string Name { get; set; } = null!;

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; } = null!;

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;
    }
}
