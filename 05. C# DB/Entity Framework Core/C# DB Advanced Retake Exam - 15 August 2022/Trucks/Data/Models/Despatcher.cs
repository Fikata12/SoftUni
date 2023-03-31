using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; } = null!;

        public string? Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; } = null!;
    }
}