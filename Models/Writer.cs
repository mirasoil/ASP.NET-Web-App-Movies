using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ispas_Teodora_Proiect.Models
{
    public class Writer
    {
        public int ID { get; set; } //cheie straina pentru entitatea Movie
        [Display(Name = "Writer Name")]
        public string WriterName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
