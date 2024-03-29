﻿using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P08_ProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}