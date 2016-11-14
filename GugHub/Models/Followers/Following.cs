using GugHub.Models.Application;

namespace GugHub.Models.Followers
{
    public class Following
    {
        public string FollowerId { get; private set; }
        public string FolloweeId { get; private set; }
        public ApplicationUser Follower { get; private set; }
        public ApplicationUser Followee { get; private set; }

        private Following() { }

        public static Following Create(string followerId, string followeeId)
        {
            return new Following()
            {
                FollowerId = followerId,
                FolloweeId = followeeId
            };
        }
    }
}