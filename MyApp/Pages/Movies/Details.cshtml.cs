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
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _db;

        public DetailsModel(AppDbContext db)
        {
            _db = db;
        }

        public Movie Movie { get; set; }

        public void OnGet(int movieId)
        {
            Movie = _db.Movies.Find(movieId);

        }
    }
}
