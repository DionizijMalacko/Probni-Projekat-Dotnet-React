using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool IsCancelled { get; set; }

        public string HostUsername { get; set; }
    
        public ICollection<UserSimpleDTO> Users { get; set; }
    }
}