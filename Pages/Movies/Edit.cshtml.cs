using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ispas_Teodora_Proiect.Data;
using Ispas_Teodora_Proiect.Models;

namespace Ispas_Teodora_Proiect.Pages.Movies
{
    public class EditModel : MovieGenresPageModel
    {
        private readonly Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext _context;
        public EditModel(Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Movie Movie { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Movie = await _context.Movie
            .Include(b => b.Writer)
            .Include(b => b.MovieGenres).ThenInclude(b => b.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Movie == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedGenreData(_context, Movie);
            ViewData["WriterID"] = new SelectList(_context.Writer, "ID",
           "WriterName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
            .Include(i => i.Writer)
            .Include(i => i.MovieGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
            movieToUpdate,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.Duration, i => i.ReleaseDate, i => i.Writer))
            {
                UpdateMovieGenres(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMovieGenres(_context, selectedCategories, movieToUpdate);
            PopulateAssignedGenreData(_context, movieToUpdate);
            return Page();
        }
    }
}
