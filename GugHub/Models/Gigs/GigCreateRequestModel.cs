using System;
using System.ComponentModel.DataAnnotations;

namespace GugHub.Models.Gigs
{
    public class GigCreateRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public DateTime GetDateTime() { return DateTime.Parse($"{Date} {Time}"); }
    }
}