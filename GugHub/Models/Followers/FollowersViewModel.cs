using GugHub.Models.Application;
using GugHub.Models.Common;
using System.Collections.Generic;

namespace GugHub.Models.Followers
{
    public class FollowersViewModel : BaseViewModel
    {
        public IEnumerable<ApplicationUser> Followers { get; set; }

        private FollowersViewModel(IEnumerable<ApplicationUser> followers, string heading)
        {
            Followers = followers;
            Heading = heading;
        }

        public static FollowersViewModel Create(IEnumerable<ApplicationUser> followers, string heading)
        {
            return new FollowersViewModel(followers, heading);
        }
    }
}