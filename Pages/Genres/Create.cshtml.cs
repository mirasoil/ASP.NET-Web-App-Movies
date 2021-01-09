using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ispas_Teodora_Proiect.Data;
using Ispas_Teodora_Proiect.Models;

namespace Ispas_Teodora_Proiect.Pages.Genres
{
    public class CreateModel : PageModel
    {
        private readonly Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext _context;

        public CreateModel(Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Genre Genre { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Genre.Add(Genre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
