using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies.Comments
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public Movie Movie { get; set; }

        public void OnGet(int movieId)
        {
            Movie = _db.Movies
                .Include("Comments")
                .FirstOrDefault(m => m.Id == movieId);

            
        }
    }
}
