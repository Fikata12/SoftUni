using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Pseudonym { get; set; }
        [Column(TypeName = "text")]
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Album> Albums { get; set; } = null!;

    }
}
