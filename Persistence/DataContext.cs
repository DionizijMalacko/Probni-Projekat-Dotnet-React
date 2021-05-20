using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //ovde idu tabele
        //public DbSet<Activity> Activities { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventUser> EventUsers { get; set; }

        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //preko ove klase imamo pristup entity builder-u
            builder.Entity<EventUser>(x => x.HasKey(aa => new {aa.AppUserId, aa.EventId}));

            builder.Entity<EventUser>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Events)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<EventUser>()
                .HasOne(u => u.Event)
                .WithMany(a => a.Users)
                .HasForeignKey(aa => aa.EventId);
        }
    }
}