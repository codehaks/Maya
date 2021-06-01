using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies.Cast
{
    public class MoviesModel : PageModel
    {
        private readonly AppDbContext _db;

        public MoviesModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Movie> MovieList { get; set; }

        public void OnGet(int actorId)
        {
            var actor = _db.Actors.Include(a => a.Movies).FirstOrDefault(a => a.Id == actorId);
            MovieList = actor.Movies.ToList();
        }
    }
}
