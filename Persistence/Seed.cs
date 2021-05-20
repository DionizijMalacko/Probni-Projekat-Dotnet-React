using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager) {

            //ovde ubacujemo entitete  //&& !context.Events.Any()
            if (!userManager.Users.Any() ) 
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

            //     var events = new List<Event> {

            //         new Event {
            //             nameof = "First Event",
            //             Date = DateTime.Now.AddMonths(-2),
            //             Description = "Activity 2 months ago",
            //             users = new List<EventUsers> {
            //                 new EventUser {
            //                     AppUser = users[0],
            //                     IsHost = true
            //                 }
            //             }
            //         }
            //     };


             }

            // await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();

        }
    }
}