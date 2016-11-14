using GugHub.Models.Common;
using GugHub.Models.Genres;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GugHub.Models.Gigs
{
    public class GigCreateResponseModel : BaseViewModel
    {
        public int Id { get; set; } = 0;
        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create"; // Fragile !!!
            }
        }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; } = DateTime.Now.ToShortDateString();

        [Required]
        [ValidTime]
        public string Time { get; set; } = "20:00";

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

        private GigCreateResponseModel() { }

        public static GigCreateResponseModel Create(GigCreateRequestModel model, IEnumerable<Genre> genres, string heading)
        {
            return new GigCreateResponseModel()
            {
                Id = model.Id,
                Date = model.Date,
                Time = model.Time,
                Venue = model.Venue,
                Genre = model.Genre,
                Genres = genres,
                Heading = heading
            };
        }

        public static GigCreateResponseModel Create(Gig model, IEnumerable<Genre> genres, string heading)
        {
            return new GigCreateResponseModel()
            {
                Id = model.Id,
                Date = model.DateTime.ToString("dd/MM/yyy"),
                Time = model.DateTime.ToString("HH:mm"),
                Venue = model.Venue,
                Genre = model.GenreId,
                Genres = genres,
                Heading = heading
            };
        }

        public static GigCreateResponseModel Create(IEnumerable<Genre> genres, string heading)
        {
            return new GigCreateResponseModel()
            {
                Genres = genres,
                Heading = heading
            };
        }
    }
}