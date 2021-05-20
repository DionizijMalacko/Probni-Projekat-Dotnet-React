using System;
using System.Collections.Generic;

namespace Domain
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool IsCancelled { get; set; }

        public ICollection<EventUser> Users { get; set; }
    }
}