using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ispas_Teodora_Proiect.Data;
using Ispas_Teodora_Proiect.Models;

namespace Ispas_Teodora_Proiect.Pages.Writers
{
    public class IndexModel : PageModel
    {
        private readonly Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext _context;

        public IndexModel(Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext context)
        {
            _context = context;
        }

        public IList<Writer> Writer { get;set; }

        public async Task OnGetAsync()
        {
            Writer = await _context.Writer.ToListAsync();
        }
    }
}
