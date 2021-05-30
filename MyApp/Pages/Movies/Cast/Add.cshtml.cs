using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies.Cast
{

    [BindProperties]
    public class AddModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindNever]
        public SelectList ActorSelectList { get; set; }
        
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public AddModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int movieId)
        {
            MovieId = movieId;

            var actors = _db.Actors.ToList();
            ActorSelectList = new SelectList(actors, "Id", "FullName");
        }

        public IActionResult OnPost()
        {
            var movie = _db.Movies.Include(m => m.Cast).FirstOrDefault(m => m.Id == MovieId);

            var actor = _db.Actors.Find(ActorId);

            if (movie.Cast is null)
            {
                movie.Cast = new List<Actor>();
            }


            movie.Cast.Add(actor);

            _db.SaveChanges();
            return RedirectToPage("./index",new { MovieId=MovieId});

        }
    }
}
