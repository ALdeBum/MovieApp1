using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        // GET: Movies/Seed
        public async Task<IActionResult> Seed()
        {
            if (!_context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Title = "Movie 1",
                        Director = "Director 1",
                        Genre = "Genre 1",
                        ReleaseYear = 2021,
                        Poster = "URL_of_poster_1",
                        Description = "Description of Movie 1"
                    },
                    new Movie
                    {
                        Title = "Movie 2",
                        Director = "Director 2",
                        Genre = "Genre 2",
                        ReleaseYear = 2020,
                        Poster = "URL_of_poster_2",
                        Description = "Description of Movie 2"
                    },
                    // Добавьте остальные фильмы аналогично
                };

                await _context.Movies.AddRangeAsync(movies);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
