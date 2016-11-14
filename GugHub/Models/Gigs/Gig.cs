using GugHub.Models.Application;
using GugHub.Models.Attendances;
using GugHub.Models.Genres;
using GugHub.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GugHub.Models.Gigs
{
    public class Gig
    {
        public int Id { get; private set; }
        public ApplicationUser Artist { get; private set; }
        public bool IsCanceled { get; private set; } = false;
        public string ArtistId { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Venue { get; private set; }
        public Genre Genre { get; private set; }
        public byte GenreId { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; }

        private Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public static Gig Create(GigCreateRequestModel model, string id, ICollection<ApplicationUser> users)
        {
            var gig = new Gig()
            {
                ArtistId = id,
                Venue = model.Venue,
                DateTime = model.GetDateTime(),
                GenreId = model.Genre
            };

            // Create a notification  
            var notification = Notification.CreateGig(gig);

            // Now iterate through all users and create a notification for each
            foreach (var user in users)
            {
                user.Notify(notification);
            }

            return gig;
        }

        public void Update(GigCreateRequestModel model)
        {
            var gig = this.MemberwiseClone() as Gig;

            // Create a notification  
            var notification = Notification.UpdateGig(gig);

            Venue = model.Venue;
            DateTime = model.GetDateTime();
            GenreId = model.Genre;

            // Now iterate through all attendees for this gig and create a notification for each
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Cancel()
        {
            IsCanceled = true;

            // Create a notification  
            var notification = Notification.CancelGig(this);

            // Now iterate through all attendees for this gig and create a notification for each
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}