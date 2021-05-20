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
        public static async Task SeedData(DataContext context, 
            UserManager<AppUser> userManager) 
        {
            
            //ovde ubacujemo entitete  //&& !context.Events.Any()
            if (!userManager.Users.Any() && !context.Events.Any()) 
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
                
                var events = new List<Event> {

                    new Event {
                        Name = "First Event",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Event 2 months ago",
                        Users = new List<EventUser>
                        {
                            new EventUser {
                                AppUser = users[0],
                                IsHost = true
                            }
                        }
                    },

                    new Event {
                        Name = "Second Event",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Event in 2 months",
                        Users = new List<EventUser>
                        {
                            new EventUser {
                                AppUser = users[0],
                                IsHost = true
                            },
                            new EventUser {
                                AppUser = users[1],
                                IsHost = false
                            },
                        }
                    },

                    new Event {
                        Name = "Third Event",
                        Date = DateTime.Now.AddDays(1),
                        Description = "Event tommorow",
                        Users = new List<EventUser>
                        {
                            new EventUser {
                                AppUser = users[1],
                                IsHost = true
                            },
                            new EventUser {
                                AppUser = users[2],
                                IsHost = false
                            },
                        }
                    },

                    new Event {
                        Name = "Fourth Event",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Event in 5 months",
                        Users = new List<EventUser>
                        {
                            new EventUser {
                                AppUser = users[0],
                                IsHost = true
                            },
                            new EventUser {
                                AppUser = users[1],
                                IsHost = false
                            },
                            new EventUser {
                                AppUser = users[2],
                                IsHost = false
                            },
                        }
                    },

                    new Event {
                        Name = "Fifth Event",
                        Date = DateTime.Now.AddDays(7),
                        Description = "Event next week",
                        Users = new List<EventUser>
                        {
                            new EventUser {
                                AppUser = users[2],
                                IsHost = true
                            },
                            new EventUser {
                                AppUser = users[0],
                                IsHost = false
                            },
                            new EventUser {
                                AppUser = users[1],
                                IsHost = false
                            },
                        }
                    },
                };

                //await context.Events.AddRangeAsync(Events);

                await context.Events.AddRangeAsync(events); 
                await context.SaveChangesAsync();   //dotnet ef database drop -p Persistence -s API  i onda samo dotnet run
            }

        }
    }
}