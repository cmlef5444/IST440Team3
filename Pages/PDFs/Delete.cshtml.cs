using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IST440Team3.Data;
using IST440Team3.Models;
using Microsoft.AspNetCore.Authorization;

namespace IST440Team3.Pages.PDFs
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IST440Team3.Data.IST440Team3Context _context;

        public DeleteModel(IST440Team3.Data.IST440Team3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Transformation Transformation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transformation = await _context.Transformation.FirstOrDefaultAsync(m => m.Id == id);

            if (Transformation == null)
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

            Transformation = await _context.Transformation.FindAsync(id);

            if (Transformation != null)
            {
                _context.Transformation.Remove(Transformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
