using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }

        //ovo je za manyToMany relationship
        public ICollection<EventUser> Events {get; set;}

        //ovo je za oneToMany
        public ICollection<Photo> Photos {get; set;}
    }
}