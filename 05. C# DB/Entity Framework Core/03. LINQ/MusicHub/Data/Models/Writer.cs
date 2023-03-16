using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Pseudonym { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = null!;
    }
}
