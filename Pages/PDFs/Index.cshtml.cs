using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IST440Team3.Data;
using IST440Team3.Models;

namespace IST440Team3.Pages.PDFs
{
    public class IndexModel : PageModel
    {
        private readonly IST440Team3.Data.IST440Team3Context _context;

        public IndexModel(IST440Team3.Data.IST440Team3Context context)
        {
            _context = context;
        }

        public IList<Transformation> Transformation { get;set; }

        public async Task OnGetAsync()
        {
            Transformation = await _context.Transformation.ToListAsync();
        }
    }
}
