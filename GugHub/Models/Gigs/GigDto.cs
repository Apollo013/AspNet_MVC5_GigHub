using GugHub.Models.Application;
using GugHub.Models.Genres;
using System;

namespace GugHub.Models.Gigs
{
    public class GigDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; } = false;
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreDto Genre { get; set; }
        public ApplicationUserDto Artist { get; set; }
    }
}