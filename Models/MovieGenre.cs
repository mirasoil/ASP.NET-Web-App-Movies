﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispas_Teodora_Proiect.Models
{
    public class MovieGenre
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
