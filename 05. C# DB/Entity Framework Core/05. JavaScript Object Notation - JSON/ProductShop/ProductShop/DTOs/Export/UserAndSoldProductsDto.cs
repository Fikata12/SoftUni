using Newtonsoft.Json;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class UserAndSoldProductsDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("soldProducts")]
        public ICollection<SoldProductDto> ProductsSold { get; set; } = null!;
    }
}
