﻿using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P05_ProductDto
    {
        [JsonProperty("name")]
        public string ProductName { get; set; } = null!;

        [JsonProperty("price")]
        public decimal ProductPrice { get; set; }

        [JsonProperty("seller")]
        public string SellerFullName { get; set; } = null!;
    }
}