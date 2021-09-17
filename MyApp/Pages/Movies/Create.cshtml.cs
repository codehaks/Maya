using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Data;
using MyApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Pages.Movies
{

    public class CreateModel : PageModel
    {
        public SelectList GenreList { get; set; }
        [BindProperty]
        public int GenreId { get; set; }
        [BindProperty]
        public IFormFile PosterFile { get; set; }

        [BindProperty]
        public bool IsWatched { get; set; }

        [BindProperty]
        public string Language { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is needed!")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Length must be between {1} and {2}")]
        public string Name { get; set; }

        [BindProperty]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessage = "Length must be between {1} and {2}")]
        public string Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Movie must have a year!")]
        [Range(1950, 2021, ErrorMessage = "Year starts with {1} to {2}")]
        public int? Year { get; set; }

        [BindProperty]
        [Range(1, 10)]
        public ScoreValue? Score { get; set; }

        private readonly AppDbContext _db;

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int movieId)
        {
            var movie = _db.Movies.Find(movieId);

            var genres = _db.Genres.ToList();

            GenreList = new SelectList(genres, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var movie = new Movie
            {
                Name = Name,
                Year = Year.Value,
                Score = Score,
                Description = Description,
                IsWatched = IsWatched,
                Language = Language,
                GenreId = GenreId
            };

            if (PosterFile is not null && PosterFile.Length > 0)
            {
                using var memory = new MemoryStream();
                await PosterFile.CopyToAsync(memory);
                movie.PosterData = memory.ToArray();
            }

            _db.Movies.Add(movie);

            _db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
