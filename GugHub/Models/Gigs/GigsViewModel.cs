using GugHub.Models.Common;
using System.Collections.Generic;

namespace GugHub.Models.Gigs
{
    public class GigsViewModel : BaseViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; private set; }
        public bool ShowActions { get; private set; }

        private GigsViewModel() { }

        public static GigsViewModel Create(IEnumerable<Gig> upcomingGigs, bool showActions, string heading)
        {
            return new GigsViewModel()
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = showActions,
                Heading = heading
            };
        }
    }
}