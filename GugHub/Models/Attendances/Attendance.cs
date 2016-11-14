using GugHub.Models.Application;
using GugHub.Models.Gigs;

namespace GugHub.Models.Attendances
{
    public class Attendance
    {
        public int GigId { get; private set; }
        public string AttendeeId { get; private set; }
        public Gig Gig { get; private set; }
        public ApplicationUser Attendee { get; private set; }

        private Attendance() { }

        public static Attendance Create(int gigId, string attendeeId)
        {
            return new Attendance()
            {
                GigId = gigId,
                AttendeeId = attendeeId
            };
        }
    }
}