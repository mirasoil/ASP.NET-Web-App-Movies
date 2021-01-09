using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ispas_Teodora_Proiect.Data;


namespace Ispas_Teodora_Proiect.Models
{
    public class MovieGenresPageModel : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;
        public void PopulateAssignedGenreData(Ispas_Teodora_ProiectContext context,
        Movie movie)
        {
            var allCategories = context.Genre;
            var movieGenres = new HashSet<int>(
            movie.MovieGenres.Select(c => c.MovieID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var cat in allCategories)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = cat.ID,
                    Name = cat.GenreName,
                    Assigned = movieGenres.Contains(cat.ID)
                });
            }
        }
        public void UpdateMovieGenres(Ispas_Teodora_ProiectContext context,
        string[] selectedCategories, Movie movieToUpdate)
        {
            if (selectedCategories == null)
            {
                movieToUpdate.MovieGenres = new List<MovieGenre>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var movieGenres = new HashSet<int>
            (movieToUpdate.MovieGenres.Select(c => c.Genre.ID));
            foreach (var cat in context.Genre)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!movieGenres.Contains(cat.ID))
                    {
                        movieToUpdate.MovieGenres.Add(
                        new MovieGenre
                        {
                            MovieID = movieToUpdate.ID,
                            GenreID = cat.ID
                        });
                    }
                }
                else
                {
                    if (movieGenres.Contains(cat.ID))
                    {
                        MovieGenre courseToRemove
                        = movieToUpdate
                        .MovieGenres
                        .SingleOrDefault(i => i.GenreID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
