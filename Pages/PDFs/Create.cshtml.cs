using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IST440Team3.Data;
using IST440Team3.Models;
using IST440Team3.Controllers;

namespace IST440Team3.Pages.PDFs
{
    public class CreateModel : PageModel
    {
        private readonly IST440Team3.Data.IST440Team3Context _context;

        public CreateModel(IST440Team3.Data.IST440Team3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Transformation Transformation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transformation.Add(Transformation);
            await _context.SaveChangesAsync();

            var PdfsController = new PdfsController(Transformation.FilePath, Transformation.CaseNumber, Transformation.EvidenceNumber);

            return RedirectToPage("./Index");
        }
    }
}
