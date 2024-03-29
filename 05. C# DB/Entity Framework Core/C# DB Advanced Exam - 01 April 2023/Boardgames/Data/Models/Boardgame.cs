﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Boardgames.Data.Models.Enums;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Range(1, 10.00)]
        public double Rating { get; set; }

        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        public CategoryType CategoryType { get; set; }

        public string Mechanics { get; set; } = null!;

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; } = null!;
        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = null!;
    }
}
