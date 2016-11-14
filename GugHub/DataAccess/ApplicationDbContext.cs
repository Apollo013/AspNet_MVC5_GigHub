using GugHub.Models.Application;
using GugHub.Models.Attendances;
using GugHub.Models.Followers;
using GugHub.Models.Genres;
using GugHub.Models.Gigs;
using GugHub.Models.Notifications;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GugHub.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendees { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GigHub");

            // Gig
            modelBuilder.Entity<Gig>().Property(g => g.Venue).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Gig>().Property(g => g.Id).IsRequired();
            modelBuilder.Entity<Gig>().Property(g => g.ArtistId).IsRequired();
            modelBuilder.Entity<Gig>().Property(g => g.GenreId).IsRequired();
            modelBuilder.Entity<Gig>().HasRequired(g => g.Genre);
            modelBuilder.Entity<Gig>().HasRequired(g => g.Artist);



            // Genre
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            modelBuilder.Entity<Genre>().Property(g => g.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(255);

            // Attendance
            modelBuilder.Entity<Attendance>().HasKey(a => new { a.GigId, a.AttendeeId });
            modelBuilder.Entity<Attendance>().Property(a => a.GigId).IsRequired();
            modelBuilder.Entity<Attendance>().Property(a => a.AttendeeId).IsRequired();
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Attendee);
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Gig).WithMany(g => g.Attendances).WillCascadeOnDelete(false);

            // Followers
            modelBuilder.Entity<Following>().HasKey(f => new { f.FollowerId, f.FolloweeId });

            // App User
            modelBuilder.Entity<ApplicationUser>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.Followers).WithRequired(f => f.Followee).WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.Followees).WithRequired(f => f.Follower).WillCascadeOnDelete(false);

            // Notifications
            modelBuilder.Entity<Notification>().HasKey(n => n.Id);
            modelBuilder.Entity<Notification>().HasRequired(n => n.Gig);

            // User Notifications
            modelBuilder.Entity<UserNotification>().HasKey(n => new { n.UserId, n.NotificationId });
            modelBuilder.Entity<UserNotification>().HasRequired(n => n.User).WithMany(u => u.Notifications).WillCascadeOnDelete(false);
            modelBuilder.Entity<UserNotification>().HasRequired(n => n.Notification).WithMany().WillCascadeOnDelete(true);



            // Base
            base.OnModelCreating(modelBuilder);
        }
    }
}