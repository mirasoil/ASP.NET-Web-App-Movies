using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ispas_Teodora_Proiect.Data;
using Ispas_Teodora_Proiect.Models;

namespace Ispas_Teodora_Proiect.Pages.Movies
{
    public class CreateModel : MovieGenresPageModel
    {
        private readonly Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext _context;

        public CreateModel(Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["WriterID"] = new SelectList(_context.Set<Writer>(), "ID", "WriterName");
            var movie = new Movie();
            movie.MovieGenres = new List<MovieGenre>();
            PopulateAssignedGenreData(_context, movie);
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {

            var newMovie = new Movie();
            if (selectedCategories != null)
            {
                newMovie.MovieGenres = new List<MovieGenre>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieGenre
                    {
                        GenreID = int.Parse(cat)
                    };
                    newMovie.MovieGenres.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
            newMovie,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.Duration, i => i.ReleaseDate, i => i.WriterID, i => i.Image))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index"); //ma redirecteaza pe 
            }
            PopulateAssignedGenreData(_context, newMovie);
            return Page();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
    }
    }
}
