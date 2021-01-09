using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Ispas_Teodora_Proiect.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "The director's name should be 'First Name Last Name'"), Required, StringLength(50, MinimumLength = 3)]

        public string Director { get; set; }
        public int Duration { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Release")]
        public DateTime ReleaseDate { get; set; }

        public int WriterID { get; set; }
        public Writer Writer { get; set; } //navigation property

        [Display(Name = "Genres")]
        public ICollection<MovieGenre> MovieGenres { get; set; }

        public string Image { get; set; }

    }
}
