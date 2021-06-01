using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Movie> MovieList { get; set; }


        public string Term { get; set; }
        public void OnGet(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                MovieList = _db.Movies.ToList();
            }
            else
            {
                MovieList = _db.Movies.Where(m => m.Name.Contains(term)).ToList();
            }

            Term = term;


        }
    }
}