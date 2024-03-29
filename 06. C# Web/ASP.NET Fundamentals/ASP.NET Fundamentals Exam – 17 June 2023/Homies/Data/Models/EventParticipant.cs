﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey("Helper")]
        public string HelperId { get; set; } = null!;

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }


        public IdentityUser Helper { get; set; } = null!;
        public Event Event { get; set; } = null!;
    }
}