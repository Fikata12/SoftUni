using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [ForeignKey("Boardgame")]
        public int BoardgameId { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Boardgame Boardgame { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
    }
}