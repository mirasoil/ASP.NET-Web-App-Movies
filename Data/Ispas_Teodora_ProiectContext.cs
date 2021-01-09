using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ispas_Teodora_Proiect.Models;

namespace Ispas_Teodora_Proiect.Data
{
    public class Ispas_Teodora_ProiectContext : DbContext
    {
        public Ispas_Teodora_ProiectContext (DbContextOptions<Ispas_Teodora_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Ispas_Teodora_Proiect.Models.Movie> Movie { get; set; }

        public DbSet<Ispas_Teodora_Proiect.Models.Writer> Writer { get; set; }

        public DbSet<Ispas_Teodora_Proiect.Models.Genre> Genre { get; set; }
    }
}
