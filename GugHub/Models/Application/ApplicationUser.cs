using GugHub.Models.Followers;
using GugHub.Models.Notifications;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GugHub.Models.Application
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees { get; set; }
        public ICollection<UserNotification> Notifications { get; set; }

        public string ImageName
        {
            get
            {
                return CreateImageName();
            }
        }

        public ApplicationUser()
        {
            Followers = new Collection<Following>();
            Followees = new Collection<Following>();
            Notifications = new Collection<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            Notifications.Add(UserNotification.Create(this, notification));
        }

        private string CreateImageName()
        {
            var sb = Name.Split(' ');
            return $"/Images/{String.Join(String.Empty, sb)}.jpg";
        }

    }
}