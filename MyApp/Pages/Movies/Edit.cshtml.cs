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
    public class EditModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Year { get; set; }

        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int movieId)
        {
            var movie = _db.Movies.Find(movieId);

            Id = movie.Id;
            Name= movie.Name;
            Year = movie.Year;
        }

        public IActionResult OnPost()
        {
            var movie = new Movie
            {
                Id=Id,
                Name = Name,
                Year = Year
            };

            _db.Movies.Update(movie);

            _db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
