using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Year { get; set; }

        private readonly AppDbContext _db;

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int movieId)
        {
            var movie = _db.Movies.Find(movieId);

            Id = movie.Id;
            Name = movie.Name;
            Year = movie.Year;
        }

        public IActionResult OnPost()
        {
            var movie = new Movie
            {
                Id = Id
            };

            _db.Movies.Remove(movie);

            _db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
