using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Event
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCancelled { get; set; } = false;

        public ICollection<EventUser> Users { get; set; } = new List<EventUser>();
    }
}