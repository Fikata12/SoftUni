﻿using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class P02_ProductDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [JsonProperty("SellerId")]
        public int SellerId { get; set; }
        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
