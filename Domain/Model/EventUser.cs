using System;

namespace Domain
{
    public class EventUser
    {   

        //many to many veza
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        //dodatna polja koja zelimo
        public bool IsHost { get; set; }

    }
}