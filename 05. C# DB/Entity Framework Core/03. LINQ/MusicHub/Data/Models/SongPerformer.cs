﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }
        public virtual Song Song { get; set; } = null!;
        public virtual Performer Performer { get; set; } = null!;
    }
}
