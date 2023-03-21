using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class P08_UsersDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [JsonProperty("users")]
        public ICollection<P08_UserDto> Users { get; set; } = null!;
    }
}
