using AutoMapper;
using GugHub.Models.Application;
using GugHub.Models.Genres;
using GugHub.Models.Gigs;
using GugHub.Models.Notifications;

namespace GugHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}