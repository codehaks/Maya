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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Actor> CastList { get; set; }
        public int MovieId { get; set; }

        public void OnGet(int movieId)
        {
            var movie = _db.Movies.Include(m=>m.Cast).FirstOrDefault(m=>m.Id==movieId);

            CastList = movie.Cast.ToList();
            MovieId = movieId;
        }
    }
}
