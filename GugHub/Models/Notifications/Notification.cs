using GugHub.Enums;
using GugHub.Models.Gigs;
using System;

namespace GugHub.Models.Notifications
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; } = DateTime.Now;
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public Gig Gig { get; private set; }
        public int GigId { get; private set; }

        private Notification() { }

        public static Notification CreateGig(Gig gig)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("Gig");
            }
            return new Notification()
            {
                Type = NotificationType.GigCreated,
                OriginalDateTime = gig.DateTime,
                OriginalVenue = gig.Venue,
                GigId = gig.Id
            };
        }

        public static Notification UpdateGig(Gig gig)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("Gig");
            }
            return new Notification()
            {
                Type = NotificationType.GigUpdated,
                OriginalDateTime = gig.DateTime,
                OriginalVenue = gig.Venue,
                GigId = gig.Id
            };
        }

        public static Notification CancelGig(Gig gig)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("Gig");
            }
            return new Notification()
            {
                Type = NotificationType.GigCanceled,
                OriginalDateTime = gig.DateTime,
                OriginalVenue = gig.Venue,
                GigId = gig.Id
            };
        }
    }
}
