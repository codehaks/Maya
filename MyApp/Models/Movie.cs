using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public enum ScoreValue
    {
        [Display(Name ="1")]
        One = 1,

        [Display(Name = "2")]
        Two = 2,

        [Display(Name = "3")]
        Three = 3,

        [Display(Name = "4")]
        Four = 4,

        [Display(Name = "5")]
        Five = 5,

        [Display(Name = "6")]
        Six = 6,

        [Display(Name = "7")]
        Seven = 7,

        [Display(Name = "8")]
        Eight = 8,

        [Display(Name = "9")]
        Nine = 9,

        [Display(Name = "10")]
        Ten = 10
    }

    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Year { get; set; }

        [Range(1,10)]
        public ScoreValue? Score { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public bool IsWatched { get; set; }

        public string Language { get; set; }

        public byte[] PosterData { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
