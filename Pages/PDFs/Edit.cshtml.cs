using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IST440Team3.Data;
using IST440Team3.Models;

namespace IST440Team3.Pages.PDFs
{
    public class EditModel : PageModel
    {
        private readonly IST440Team3.Data.IST440Team3Context _context;

        public EditModel(IST440Team3.Data.IST440Team3Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransformationExists(Transformation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransformationExists(int id)
        {
            return _context.Transformation.Any(e => e.Id == id);
        }
    }
}
