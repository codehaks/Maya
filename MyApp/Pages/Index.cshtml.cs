using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public int Score { get; set; }

        public SelectList GenreList { get; set; }

        public string OrderBy { get; set; }

        public void OnGet(string term, int score, int genreId,string sortBy="",string orderBy="desc")
        {

            var genres = _db.Genres.ToList();
            GenreList = new SelectList(genres, "Id", "Name");

            IQueryable<Movie> movieQuery;

            if (string.IsNullOrEmpty(term))
            {
                movieQuery = _db.Movies.Include(m => m.Genre);
            }
            else
            {
                movieQuery = _db.Movies.Include(m => m.Genre).Where(m => m.Name.Contains(term));
            }

            if (score > 0)
            {
                movieQuery = movieQuery.Where(m => m.Score != null && (int)m.Score >= score);
            }

            if (genreId > 0)
            {
                movieQuery = movieQuery.Where(m => m.Genre.Id == genreId);
            }

            if (string.IsNullOrEmpty(sortBy)==false)
            {
                if (sortBy=="year")
                {
                    if (orderBy=="desc")
                    {
                        movieQuery = movieQuery.OrderByDescending(m => m.Year);
                        OrderBy = "asc";
                    }
                    else
                    {
                        movieQuery = movieQuery.OrderBy(m => m.Year);
                        OrderBy = "desc";
                    }
                    
                }
            }


            MovieList = movieQuery.ToList();

            Term = term;



        }
    }
}