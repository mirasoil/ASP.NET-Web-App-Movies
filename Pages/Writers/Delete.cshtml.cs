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
    public class DeleteModel : PageModel
    {
        private readonly Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext _context;

        public DeleteModel(Ispas_Teodora_Proiect.Data.Ispas_Teodora_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Writer Writer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Writer = await _context.Writer.FirstOrDefaultAsync(m => m.ID == id);

            if (Writer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Writer = await _context.Writer.FindAsync(id);

            if (Writer != null)
            {
                _context.Writer.Remove(Writer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
