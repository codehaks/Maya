using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="Name is needed!")]
        [StringLength(maximumLength:50,MinimumLength =2,ErrorMessage = "Length must be between {1} and {2}")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Movie must have a year!")]
        [Range(1950,2021,ErrorMessage ="Year starts with {1} to {2}")]
        public int? Year { get; set; }

        private readonly AppDbContext _db;

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var movie = new Movie
            {
                Name = Name,
                Year = Year.Value
            };

            _db.Movies.Add(movie);

            _db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
